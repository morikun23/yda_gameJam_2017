using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : MonoBehaviour {

	private float m_distanceToPlayer;
	private Vector2 m_direction;

	private float m_speed;

	IPhantomState m_currentState;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PhaseTransition(IPhantomState arg_nextPhase) {
		m_currentState.OnExit(this);
		m_currentState = arg_nextPhase;
		m_currentState.OnEnter(this);
	}

	public float GetSpeed() {
		return m_speed;
	}
}
