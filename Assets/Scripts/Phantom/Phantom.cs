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

		Vector3 playerPos = PlayerManager.Instance.Player.transform.position;
		Vector3 myPos = this.transform.position;

		m_direction = playerPos - myPos;
		m_distanceToPlayer = Vector2.Distance(playerPos , myPos);


		//ステートの処理を実行
		m_currentState.OnUpdate(this);
	}

	public void Initialize() {
		m_speed = 0.5f;
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

	public float GetDistanceToPlayer() {
		return m_distanceToPlayer;
	}

	public PlayerBase.State GetCurrentState() {
		return m_currentState.GetCurrentState();
	}
	
}
