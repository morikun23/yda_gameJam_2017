using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ハンサムの移動やブスと当たった時のリアクション
/// </summary>
public class Hansam : MonoBehaviour {
    float hansam_spd = 0.015f;    //ハンサムのスピード
    public Transform Player;  //ブス追尾のためにinspectorからブス格納
    int LR = 0;
    float rad;
    Vector2 Posistion;

    public enum Hansam_status{//ハンサムの状態管理をenumで番号付け
        normal, //まだイケメン(0)
        stay,   //AoS(1)
        ugly    //ブサイクなう(2)
    }

    public Hansam_status status;//ハンサムのステータス

	// Use this for initialization
	void OnEnable () {
        LR = Random.Range(0, 2);    //左右どっちに掃けるかをランダムで決める;
        status = Hansam_status.normal;//ハンサムの初期値はやっぱりイケメン
        rad = Mathf.Atan2(
            Player.transform.position.y - transform.position.y,
            Player.transform.position.x - transform.position.x);
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
       
        switch (status)
        {
            
            case Hansam_status.normal://ハンサムどぇ～す
               

                break;
            case Hansam_status.stay://AoS(アタック・オブ・スタンド)中に範囲内のハンサムは「時は止まる」
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
    /*/// <summary>
    /// 当たった時のリアクション
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if ()
        {
            //ブスと当たった時にブス(大山)から硬直発動の関数を発動
            OnHit();
        }
        //アタック・オブ・スタンド時に当たった時にブスになる(タイミングはAoS発動時にBOX判定でハンサム固定)
        if(){
           status = Hansam_status.stay
        }
        //ブスになる
        if ()
        {
            status = Hansam_status.ugly;
        }
    }*/
}
