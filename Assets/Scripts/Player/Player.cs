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
    float chargeSpeed = 0.01f;

    //硬直時間
    float stopTime = 3;

    //プレイヤーの各状態を表すステート
    enum PlayerState
    {
        Stop,//ストップ
        Move,//動いてる状態
        Charge,//スタンドを飛ばしている状態
        Attacking,//スタンドとどっきんぐ中☆
        Dameging//硬直なう
    }

    PlayerState state;

    // Use this for initialization
    void Start () {

        state = PlayerState.Move;


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

            case PlayerState.Move:

                playerMove(playerSpeed);

                //左クリックでチャージStateへ移行
                if (Input.GetMouseButtonDown(0)) state = PlayerState.Charge;

                break;

            case PlayerState.Charge:
                playerMove(chargeSpeed);

                //左クリックを離すとアタックStateへ移行
                if (Input.GetMouseButtonUp(0)) state = PlayerState.Attacking;

                break;

            case PlayerState.Attacking:

                break;

            case PlayerState.Dameging:

                //ダメージ演出したい

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

    /// <summary>
    /// エネミー側で呼んでもらうダメージ関数
    /// </summary>
    public void OnHit()
    {
        state = PlayerState.Dameging;
        Invoke("ChengeStateMove", stopTime);
    }

    /// <summary>
    /// Moveステート変更関数
    /// </summary>
    void ChengeStateMove()
    {
        state = PlayerState.Move;

    }
}
