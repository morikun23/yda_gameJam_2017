using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBase{

    //マウスのポジション
    Vector3 screenMousePosition;
    // スクリーン座標をワールド座標に変換した位置座標
    Vector3 mousePosition;

    //プレイヤーの移動量
    float playerSpeed = 0.02f;
    float chargeSpeed = 0.01f;

    //硬直時間
    float stopTime = 3;

    //点滅用
    SpriteRenderer renderer;
    float nextTime = 0;
    float interval = 0.1f;

    //移動制限の壁
    GameObject UpLeftWall, DownRightWall;

    //スタンドを出す方向を示す矢印関連
    GameObject standDirectionArrow;

    //エフェクト
    public GameObject effect;

    float attackingTime = 0.5f;

    // Use this for initialization
    void Start () {

        state = State.Move;
        renderer = GetComponent<SpriteRenderer>();

        screenMousePosition = Input.mousePosition;
        //Debug.Log(mousePosition);

        mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);

        mousePosition.z = transform.position.z;

        UpLeftWall = GameObject.Find("UpLeftWall");
        DownRightWall = GameObject.Find("DownRightWall");

        standDirectionArrow = transform.FindChild("StandDirection").gameObject;

    }
	
	// Update is called once per frame
	void Update () {

		if (GameManager.Instance.GetCurrentPhase() != "Playing") return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnHit();
        }

        //各ステートごとで処理
        switch (state)
        {

            case State.Move:

                playerMove(playerSpeed);

                //左クリックでチャージStateへ移行
                if (Input.GetMouseButtonDown(0))
                {
                    Sound sound;
                    sound = new Sound();
                    sound.SetSound(SE.Charge);
                    sound.audioSource.Play();

                    state = State.Charge;

                }
                break;

            case State.Charge:
                playerMove(chargeSpeed);

                //左クリックを離すとアタックStateへ移行
                if (Input.GetMouseButtonUp(0))
                {
                    Sound sound;
                    sound = new Sound();
                    sound.SetSound(SE.Attack);
                    sound.audioSource.Play();

                    state = State.Attacking;
					Invoke("ChengeStateMove" , attackingTime);
				}
                break;

            case State.Attacking:

                GetComponent<Animator>().SetTrigger("Booon");

                break;

            case State.Damaging:

                playerMove(chargeSpeed);

                //ダメージ演出したい
                if (Time.time > nextTime)
                {
                    renderer.enabled = !renderer.enabled;

                    nextTime += interval;
                }

                break;

        }

        transform.position = (new Vector3(Mathf.Clamp(transform.position.x, UpLeftWall.transform.position.x + renderer.bounds.size.x / 2, DownRightWall.transform.position.x - renderer.bounds.size.x / 2),
            Mathf.Clamp(transform.position.y, DownRightWall.transform.position.y + renderer.bounds.size.y / 2, UpLeftWall.transform.position.y - renderer.bounds.size.y / 2),
            transform.position.z));

    }

    /// <summary>
    /// プレイヤーの移動関数
    /// 色んなステートで呼ばれるよ
    /// 矢印もここで管理します
    /// </summary>
    /// 引数：速度
    void playerMove(float arg_speed)
    {

        //マウスの位置取得
        screenMousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);

        mousePosition.z = 10;

        //以下矢印の動き

        Vector3 diff = (mousePosition - transform.position).normalized;
        standDirectionArrow.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
        standDirectionArrow.transform.rotation = Quaternion.Euler(0, 0, standDirectionArrow.transform.rotation.eulerAngles.z);

        //以下プレイヤーの動き

        float x = 0, y = 0;

        if(transform.position.x < mousePosition.x)
        {
            x += arg_speed;
            renderer.flipX = true;
        }
        else
        {
            x -= arg_speed;
            renderer.flipX = false;
        }

        if (transform.position.y > mousePosition.y)
        {
            y -= arg_speed;
        }
        else
        {
            y += arg_speed;
        }

        if (Mathf.Abs(Mathf.Abs(transform.position.x) - Mathf.Abs(mousePosition.x)) <= arg_speed+0.5f) x = 0;
        if (Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(mousePosition.y)) <= arg_speed+0.6f) y = 0;

        
        transform.position += new Vector3(x, y, 0);
    }

    /// <summary>
    /// エネミー側で呼んでもらうダメージ関数
    /// </summary>
    public void OnHit()
    {
        if (state == State.Damaging || state == State.Attacking) return;

        nextTime = Time.time;
        state = State.Damaging;
        Sound sound;
        sound = new Sound();
        sound.SetSound(SE.Damage);
        sound.audioSource.Play();
        Invoke("ChengeStateMove", stopTime);
    }

    /// <summary>
    /// Moveステート変更関数
    /// </summary>
    void ChengeStateMove()
    {
        nextTime = 0;
        renderer.enabled = true;
        state = State.Move;

    }

    /// <summary>
    /// 現在のプレイヤーのステートを取得
    /// </summary>
    public State GetState()
    {
        return state;
    }

    public Vector2 GetDirection() {
		return mousePosition - transform.position; 
	}
}
