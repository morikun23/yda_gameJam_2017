using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private static PlayerManager m_instance;

    public static PlayerManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<PlayerManager>();
            }
            return m_instance;
        }
    }

    private PlayerManager() { }

    enum PlayerManagerState
    {
        Move,//動いてる状態
        Charge,//スタンドを飛ばしている状態
        Attacking,//スタンドとどっきんぐ中☆
        Dameging//硬直なう

    }

    PlayerManagerState state;

    //ドッキングポジション
    public Vector3 centerPosition;

    //攻撃範囲
    float attackArea;

    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void Initialize()
    {
        state = PlayerManagerState.Move;
        centerPosition = Vector3.zero;
        attackArea = 1;
    }
}
