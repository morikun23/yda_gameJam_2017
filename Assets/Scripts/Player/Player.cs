using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //マウスのポジション
    Vector3 screenMousePosition;
    // スクリーン座標をワールド座標に変換した位置座標
    Vector3 mousePosition;

    //プレイヤーの移動量
    float playerSpeed = 0.02f;

    //硬直時間
    float stopTime = 3;

    //プレイヤーの各状態を表すステート
    enum PlayerState
    {
        Idle,//通常　動いてる状態
        Charge,//スタンドを飛ばしている状態
        Attacking,//スタンドとどっきんぐ中☆
        Dameging//硬直なう
    }

    PlayerState state;

    // Use this for initialization
    void Start () {

        state = PlayerState.Idle;


        screenMousePosition = Input.mousePosition;
        //Debug.Log(mousePosition);

        mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);

        mousePosition.z = transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {

        //各ステートごとで処理
        switch (state)
        {

            case PlayerState.Idle:

                playerMove(playerSpeed);

                break;

            case PlayerState.Charge:
                

                break;

            case PlayerState.Attacking:

                break;

            case PlayerState.Dameging:

                

                break;

        }


        
	}

    /// <summary>
    /// プレイヤーの移動関数
    /// 色んなステートで呼ばれるよ
    /// </summary>
    /// 引数：速度
    void playerMove(float arg_speed)
    {
        float x = 0, y = 0;

        screenMousePosition = Input.mousePosition;
        //Debug.Log(mousePosition);

        mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);

        mousePosition.z = transform.position.z;

        if(transform.position.x < mousePosition.x)
        {
            x += arg_speed;
        }
        else
        {
            x -= arg_speed;
        }

        if (transform.position.y > mousePosition.y)
        {
            y -= arg_speed;
        }
        else
        {
            y += arg_speed;
        }

        transform.position += new Vector3(x, y, 0);
    }

}
