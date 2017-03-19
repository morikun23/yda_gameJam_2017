using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : PlayerBase {

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
	
	private Player m_player;

    // Use this for initialization
    void Start () {
        Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
    void Initialize()
    {
        state = State.Move;
        centerPosition = Vector3.zero;
        attackArea = 1;
		m_player = FindObjectOfType<Player>();
    }
}
