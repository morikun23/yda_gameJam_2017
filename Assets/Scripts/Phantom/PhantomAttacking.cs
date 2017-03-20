using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomAttacking : MonoBehaviour , IPhantomState{

	private Vector3 m_startPosition;
	private Vector3 m_endPosition;
	private int m_t;
	private const int MAX = 30;

	public void OnEnter(Phantom arg_phantom) {
		m_startPosition = arg_phantom.transform.position;
		m_endPosition = PlayerManager.Instance.Player.transform.position;
		m_t = 0;
	}

	public void OnUpdate(Phantom arg_phantom) {

		if (Arrived()) {
			return;
		}

		//スムーズに補完しながら移動
		Vector3 velocity = (m_endPosition - m_startPosition) / MAX;
		arg_phantom.transform.position += velocity;
		m_t++;		
	}

	public void OnExit(Phantom arg_phantom) {

	}

	public PlayerBase.State GetCurrentState() {
		return PlayerBase.State.Attacking;
	}

	private bool Arrived() {
		return m_t >= MAX;
	}
}
