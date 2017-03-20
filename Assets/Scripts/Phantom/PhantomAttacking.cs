using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomAttacking : MonoBehaviour , IPhantomState{

	private float m_chargingCount;

	public void OnEnter(Phantom arg_phantom) {
		m_chargingCount = 1;
		arg_phantom.GetComponent<BoxCollider2D>().enabled = true;
	}

	public void OnUpdate(Phantom arg_phantom) {

		if (m_chargingCount > 0f) {
			m_chargingCount -= Time.deltaTime / arg_phantom.GetSpeed();
		}

		Player player = PlayerManager.Instance.Player;

		arg_phantom.transform.position =
			player.transform.position +
			(Vector3)player.GetDirection().normalized * 4f * m_chargingCount;
	}

	public void OnExit(Phantom arg_phantom) {

	}

	public PlayerBase.State GetCurrentState() {
		return PlayerBase.State.Attacking;
	}
	
}
