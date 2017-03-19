using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ハンサムの移動やブスと当たった時のリアクション
/// </summary>
public class Hansam : MonoBehaviour {
    Vector2 hansam_spd = new Vector2(0.5f,0.5f);    //ハンサムのスピード
    public Transform Player;  //ブス追尾のためにinspectorからブス格納

    public enum Hansam_status{//ハンサムの状態管理をenumで番号付け
        normal, //まだイケメン(0)
        stay,   //AoS
        ugly    //ブサイクなう(2)
    }

    public Hansam_status status;

	// Use this for initialization
	void Start () {
        status = Hansam_status.normal;//ハンサムの初期値はやっぱりイケメン
	}

	
	// Update is called once per frame
	void Update () {
        Move_Hansam();
	}



    /// <summary>
    /// ハンサムの動きの管理＆実行
    /// </summary>
    void Move_Hansam()
    {
        Vector2 Position = transform.position;
        switch (status)
        {
            case Hansam_status.normal://ハンサムどぇ～す



                break;
            case Hansam_status.stay://AoS(アタック・オブ・スタンド)中に範囲内のハンサムは「時は止まる」
                return;

            case Hansam_status.ugly://ブッさ
                int LR = Random.Range(0,1);//左右どっちに掃けるかをランダムで決める
                switch (LR)//L = 左(0),R = 右(1)
                {
                    case '0'://左に掃ける
                        Position.x += hansam_spd.x * -1.5f;
                        break;
                    case '1'://右に掃ける
                        Position.x += hansam_spd.x * 1.5f;
                        break;
                }
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 当たった時のリアクション
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        
        /*if ()
        {
            //ブスと当たった時にブス(大山)から硬直発動の関数を発動
        }
        //アタック・オブ・スタンド時に当たった時にブスになる(タイミングはAoS発動時にBOX判定でハンサム固定)
        if ()
        {
            status = Hansam_status.ugly;
        }*/
    }
}
