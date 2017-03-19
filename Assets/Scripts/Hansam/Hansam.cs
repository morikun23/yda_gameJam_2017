using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ハンサムの移動やブスと当たった時のリアクション
/// </summary>
public class Hansam : MonoBehaviour {
    float hansam_spd = 0.01f;    //ハンサムのスピード
    public Transform Player;     //ブス追尾のためにinspectorからブス格納
    int LR = 0;                  //ブス化後に掃ける方向を決める
    float rad;
    bool busu = false;           //ブス化
    public enum Hansam_status{//ハンサムの状態管理をenumで番号付け
        normal, //まだイケメン(0)
        //stay,   //AoS(1)
        hold,
        ugly    //ブサイクなう(2)
    }

    public Hansam_status status;//ハンサムのステータス

 
    // Use this for initialization
    void OnEnable () {
        LR = Random.Range(0, 2);    //左右どっちに掃けるかをランダムで決める;
        status = Hansam_status.normal;//ハンサムの初期値はやっぱりイケメン
        
    }

	
	// Update is called once per frame
	void Update () {
        
        Move_Hansam();

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
        // 現在の位置に加算減算を行ったPositionを代入
        transform.position = Position;
    }



    /// <summary>
    /// ハンサムの動きの管理＆実行
    /// </summary>
    void Move_Hansam()
    {
       
        switch (status)
        {
            
            case Hansam_status.normal://ハンサムどぇ～す
                Tracking(hansam_spd);
                busu = false;

                break;
            /* case Hansam_status.stay://AoS(アタック・オブ・スタンド)中に範囲内のハンサムは「時は止まる」
                 break;*/

            case Hansam_status.hold:
                Tracking();

                break;
            case Hansam_status.ugly://ブッさ
                switch (LR)//L = 左(0),R = 右(1)
                {

                    case 0://左に掃ける
                        transform.position += new Vector3(hansam_spd * 10, 0, 0);
                        break;
                    case 1://右に掃ける
                        transform.position -= new Vector3(hansam_spd * 10, 0, 0);
                        break;
                }
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
        
        if (other.gameObject.CompareTag("Player"))
        {
            //ブスと当たった時にブス(大山)から硬直発動の関数を発動
            GetComponent<Player>().OnHit();
            status = Hansam_status.ugly;
            busu = true;
        }
        /*//ザ・ワールド
        if(other.gameObject.tag == "BusuArea")
        {
            status = Hansam_status.stay;
        }*/
        //アタック・オブ・スタンド時に当たった時にブスになる(タイミングはAoS発動時にBOX判定でハンサム固定)
        if (other.gameObject.tag == "BusuStand")
        {
            status = Hansam_status.hold;
        }
    }
}
