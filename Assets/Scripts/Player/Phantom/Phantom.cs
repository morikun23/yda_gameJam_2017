using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : MonoBehaviour {

	private float m_distanceToPlayer;
	private Vector2 m_direction;

	private float m_speed;

	private int m_chargingCount;

	IPhantomState m_currentState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		m_currentState.OnUpdate(this);
	}

	public void StateTransition(IPhantomState arg_nextPhase) {
		m_currentState.OnExit(this);
		m_currentState = arg_nextPhase;
		m_currentState.OnEnter(this);
	}

	public float GetSpeed() {
		return m_speed;
	}

	public void Charge() {
		StateTransition(new PhantomCharge());
	}
}
