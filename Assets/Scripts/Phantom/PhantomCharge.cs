using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomCharge : MonoBehaviour , IPhantomState{

	private float m_chargingCount;

	public void OnEnter(Phantom arg_phantom) {
		arg_phantom.gameObject.SetActive(true);
		m_chargingCount = 0;
	}

	public void OnUpdate(Phantom arg_phantom) {

		if (arg_phantom.GetDistanceToPlayer() < 5f) {
			m_chargingCount += Time.deltaTime;
		}
		
		Player player = PlayerManager.Instance.Player;

		arg_phantom.transform.position =
			player.transform.position +
			(Vector3)player.GetDirection().normalized * m_chargingCount;

	}

	public void OnExit(Phantom arg_phantom) {

	}

	public PlayerBase.State GetCurrentState() {
		return PlayerBase.State.Charge;
	}
}
