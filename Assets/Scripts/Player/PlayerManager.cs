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
	public Player Player {
		get { return m_player; }
	}

	private Phantom m_phantom;

    // Use this for initialization
    void Start () {
        Initialize();
		m_player = FindObjectOfType<Player>();
		m_phantom = FindObjectOfType<Phantom>();
	}
	
	// Update is called once per frame
	void Update () {
		if (true) {

		}
	}
	
    public void Initialize() {
        state = State.Move;
        centerPosition = Vector3.zero;
        attackArea = 1;
		m_player = FindObjectOfType<Player>();
    }

	public void Charge() {
		m_phantom.StateTransition(new PhantomCharge());
	}
}
