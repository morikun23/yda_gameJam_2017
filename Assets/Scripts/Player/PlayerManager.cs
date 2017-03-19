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

		switch (Player.GetState()) {
			case PlayerBase.State.Move: ConvertStateIfNeed(PlayerBase.State.Move , new PhantomMove()); break;
			case PlayerBase.State.Charge: ConvertStateIfNeed(PlayerBase.State.Charge , new PhantomCharge()); break;
			case PlayerBase.State.Attacking: ConvertStateIfNeed(PlayerBase.State.Attacking , new PhantomAttacking()); break;
			case PlayerBase.State.Damaging: ConvertStateIfNeed(PlayerBase.State.Damaging , new PhantomDamaging()); break;
		}
		if (Player.GetState() == PlayerBase.State.Charge) {
			//チャージ開始
			m_phantom.StateTransition(new PhantomCharge());
		}
		if (Player.GetState() == PlayerBase.State.Attacking) {
			//攻撃開始
			
		}
	}
	
	private void ConvertStateIfNeed(PlayerBase.State arg_playerState,IPhantomState arg_phantomState) {
		if (IsSameState(arg_playerState , m_phantom.GetCurrentState())) return;
		m_phantom.StateTransition(arg_phantomState);
	}

	private bool IsSameState(PlayerBase.State arg_a,PlayerBase.State arg_b) {
		return arg_a == arg_b;
	}

    public void Initialize() {
     	m_player = FindObjectOfType<Player>();
    }
	
}