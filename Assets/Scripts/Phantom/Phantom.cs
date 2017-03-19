using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : PlayerBase {

	private float m_distanceToPlayer;
	private Vector2 m_direction;

	private float m_speed;

	IPhantomState m_currentState;

	// Use this for initialization
	void Start () {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		m_currentState.OnUpdate(this);
	}

	public void Initialize() {
		m_currentState = new PhantomMove();
		m_currentState.OnEnter(this);
	}

	public void StateTransition(IPhantomState arg_nextPhase) {
		m_currentState.OnExit(this);
		m_currentState = arg_nextPhase;
		m_currentState.OnEnter(this);
	}

	public float GetSpeed() {
		return m_speed;
	}
	
	public Vector2 GetDirection() {
		return m_direction;
	}

	public PlayerBase.State GetCurrentState() {
		return m_currentState.GetCurrentState();
	}
}
