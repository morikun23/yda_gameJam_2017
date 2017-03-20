using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ハンサムの移動やブスと当たった時のリアクションを管理したクラス
/// </summary>
public class Hansam : MonoBehaviour {
    SpriteRenderer Deterioration;  //スプライトをブスに変更する
    float hansam_spd = 0.01f;      //ハンサムのスピード
    public Transform Player;       //ブス追尾のためにinspectorからブス格納
    int LR = 0;                    //ブス化後に掃ける方向を決める
    float rad;
    bool ishold = false;             //ホールド中か否か
    SpriteRenderer sprite_reverse; //左右移動で向きを変えるための変数
    BoxCollider2D escape;          //ブスになったハンサムが逃げる時にあたり判定をなくすため
    public Sprite deterioration;    //ブス化(劣化)

    GameObject ase;//汗
    bool aseFlag;
    float nextTime;
    float interval;

    private class SandInfo {
		public Phantom m_phantom { get; private set; }
		public Vector2 m_distance { get; private set; }

		public void Set(Hansam arg_hansam,Phantom arg_phantom) {
			m_phantom = arg_phantom;
			m_distance = arg_hansam.transform.position - arg_phantom.transform.position;
		}
	}

	SandInfo m_sandInfo = new SandInfo();

    public enum Hansam_status{//ハンサムの状態管理をenumで番号付け
        normal,  //まだイケメン(0)
        //stay,  //AoS(1)
        hold,    //AoSが「発動中」にブスタンドに触れた時の状態(1)
        ugly     //ブサイクなう(2)
    }

    Hansam_status status;//ハンサムのステータス
  
    // Use this for initialization
    void OnEnable () {//inspector上でオブジェクトが「trueになった時」に呼び出される関数
        LR = Random.Range(0, 2);                          //左右どっちに掃けるかをランダムで決める(0以上2未満→int型のため実質0か1)
        status = Hansam_status.normal;                    //ハンサムの初期値はやっぱりイケメン
        sprite_reverse = GetComponent<SpriteRenderer>();
        escape = GetComponent<BoxCollider2D>();
        Deterioration = gameObject.GetComponent<SpriteRenderer>();
		escape.enabled = true;
		GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Hansam/Hansam");
		ishold = false;
        ase = transform.FindChild("ase").gameObject;
        ase.SetActive(false);
        nextTime = 0;
        interval = 0.1f;
        aseFlag = false;
    }

	
	// Update is called once per frame
	void Update () {
        Move_Hansam();//ハンサム移動しまー
	}

    /// <summary>
    /// 追尾する関数(引数は速度でーす)
    /// </summary>
    /// <param name="spd"></param>
    void Tracking(float spd)
    {
        rad = Mathf.Atan2(
                Player.transform.position.y - transform.position.y,
                Player.transform.position.x - transform.position.x);
        Vector2 Position = transform.position;

        Position.x += spd * Mathf.Cos(rad);
        Position.y += spd * Mathf.Sin(rad);
        
        //向き変え(ごり押し)
        if (transform.position.x > Player.transform.position.x + 0.2)
            sprite_reverse.flipX = false;
        else if (transform.position.x < Player.transform.position.x - 0.2)
            sprite_reverse.flipX = true;

        // 現在の位置に加算減算を行ったPositionを代入
        transform.position = Position;
    }



    /// <summary>
    /// ハンサムの動きの管理＆実行
    /// </summary>
    void Move_Hansam()
    {
       
        switch (status)//状態により行動パターンが変わる
        {
            
            case Hansam_status.normal://まだ彼がハンサムである時の時代(ブスを追尾してくる)
                Tracking(hansam_spd); //

                break;
            /* case Hansam_status.stay://AoS(アタック・オブ・スタンド)中に範囲内のハンサムは「時は止まる」
                 break;*/

            case Hansam_status.hold://彼がAoS「発動中」のブススタンドに捕まってしまいました。。。(ブスタンドにホールドされた)
			transform.position = m_sandInfo.m_phantom.transform.position;
                break;

            case Hansam_status.ugly://もう彼は以前のハンサムではなく、醜いブスに成り下がってしまいました(ブス化)
                //ダメージ演出したい
                if (Time.time > nextTime && aseFlag == true)
                {
                    ase.SetActive(!ase.active);

                    nextTime += interval;
                }
                StartCoroutine("Escape_Coroutine");//0.5秒後に逃げる
			break;

            default:
                LR = 0;
                break;
        }
    }

    /// <summary>
    /// 当たった時のリアクション
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {

        if (status == Hansam_status.ugly) return;

        if (other.gameObject.CompareTag("Player"))
        {
            if (ishold)
            {
                Sound sound;
                sound = new Sound();
                sound.SetSound(SE.BusuHenka);
                sound.audioSource.Play();
                status = Hansam_status.ugly;
                
                GameManager.Instance.AddKilledCount();
				Explosion();
            }
            else {//ホールド中でなければプレイヤーにダメージ処理
                //ブスと当たった時にブス(大山)から硬直発動の関数を発動
                other.gameObject.GetComponent<Player>().OnHit();
                status = Hansam_status.ugly;
            }

			
		}

        //アタック・オブ・スタンドに当たった時にホールド状態になる
        if (other.gameObject.tag == "BusuStand")
        {
			m_sandInfo.Set(this , other.GetComponent<Phantom>());
            ishold = true;
            status = Hansam_status.hold;//ハンサムの状態をホールド状態にする


        }
    }

	/// <summary>
	/// 境界から出た時のアクション
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag("Border")) {
			this.gameObject.SetActive(false);
		}
	}

	/// <summary>
	/// ハンサムをブスに変えたときにすぐに逃げずに少しstay
	/// </summary>
	/// <returns></returns>
	IEnumerator Escape_Coroutine()
    {
        //ここで見た目変更の処理
        Deterioration.sprite = deterioration;
        
        yield return new WaitForSeconds(0.5f); // num秒待機
        switch (LR)//L = 左(0),R = 右(1)
        {
            case 0://左に掃ける
                transform.position -= new Vector3(hansam_spd * 10f, 0f, 0f);
                sprite_reverse.flipX = false;
                break;
            case 1://右に掃ける
                transform.position += new Vector3(hansam_spd * 10f, 0f, 0f);
                sprite_reverse.flipX = true;
                break;
        }
    }

	/// <summary>
	/// 爆発エフェクトを出すよ
	/// </summary>
	void Explosion() {
        Sound sound = new Sound();
        sound.SetSound(SE.Bomb);
        sound.SetPosition(transform.position);
        sound.audioSource.Play();

        ase.SetActive(true);
        nextTime = Time.time;
        aseFlag = true;

        GameObject eff = Instantiate(Resources.Load<GameObject>("Effect/Explosion") , transform.position , Quaternion.identity);
		Invoke("ChangeForm" , 0.5f);
		Destroy(eff , 1);
	}

	void ChangeForm() {
		GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Hanbusa/Hanbusa");
	}
}
