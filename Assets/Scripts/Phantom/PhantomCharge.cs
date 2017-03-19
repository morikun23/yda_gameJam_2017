using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomCharge : MonoBehaviour , IPhantomState{

	private int m_chargingCount;

	public void OnEnter(Phantom arg_phantom) {
		arg_phantom.gameObject.SetActive(true);
	}

	public void OnUpdate(Phantom arg_phantom) {

		m_chargingCount++;

		arg_phantom.transform.position =
			PlayerManager.Instance.Player.transform.position +
			(Vector3)arg_phantom.GetDirection().normalized * m_chargingCount;

	}

	public void OnExit(Phantom arg_phantom) {

	}

	public PlayerBase.State GetCurrentState() {
		return PlayerBase.State.Charge;
	}
}
