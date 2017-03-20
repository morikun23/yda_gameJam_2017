using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomCharge : MonoBehaviour , IPhantomState{

	private float m_chargingCount;

	public void OnEnter(Phantom arg_phantom) {
		arg_phantom.gameObject.SetActive(true);
		m_chargingCount = 0;
		arg_phantom.GetComponent<BoxCollider2D>().enabled = false;
	}

	public void OnUpdate(Phantom arg_phantom) {

		float bonusScale = GameManager.Instance.GetChargedPower();
		if (bonusScale > 1.8f) { bonusScale = 1.8f; }
		arg_phantom.transform.localScale = new Vector3(bonusScale , bonusScale , 1);

		if (m_chargingCount < 1f) {
			m_chargingCount += Time.deltaTime / arg_phantom.GetSpeed();
		}
		
		Player player = PlayerManager.Instance.Player;

		arg_phantom.transform.position =
			player.transform.position +
			(Vector3)player.GetDirection().normalized * 4f * m_chargingCount;

	}

	public void OnExit(Phantom arg_phantom) {

	}

	public PlayerBase.State GetCurrentState() {
		return PlayerBase.State.Charge;
	}
}
