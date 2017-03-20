using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaViewer : MonoBehaviour {

	private LineRenderer m_renderer;

	// Use this for initialization
	void Start () {
		m_renderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		PlayerManager playerManager = PlayerManager.Instance;

		m_renderer.SetVertexCount((playerManager.Phantom.gameObject.activeInHierarchy)? 2:0);
		m_renderer.startWidth = 1;
		m_renderer.endWidth = GameManager.Instance.GetChargedPower();
		m_renderer.SetPositions(new Vector3[2] {
			playerManager.Player.transform.position + Vector3.back ,
				playerManager.Phantom.transform.position + Vector3.back}
		);

	}
}
