using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Generator : MonoBehaviour {

	[SerializeField]
	private float m_interval;

	private GameObject m_hansamPrefab;
	
	private List<Hansam> m_hansams;

	// Use this for initialization
	public void Initialize () {
		m_hansamPrefab = Resources.Load<GameObject>("Prefabs/Hansam");
		Generate(2);
		StartCoroutine(Exec());
	}
	
	private IEnumerator Exec() {
		while (true) {
			if (GameManager.Instance.GetCurrentPhase() == "Playing") {
				List<Hansam> activeHansams =
					m_hansams.Where(_ => !_.gameObject.activeInHierarchy).ToList();
				foreach (Hansam hansam in activeHansams) {
					hansam.gameObject.SetActive(true);
					hansam.transform.position = this.transform.position;
					break;
				}
			}
			yield return new WaitForSeconds(Random.Range(5,20));
		}
	}

	public void Generate(int arg_max) {

		m_hansams = new List<Hansam>();

		for (int i = 0; i < arg_max; i++) {
			Hansam hansam = Instantiate(m_hansamPrefab ,
				transform.position , Quaternion.identity).GetComponent<Hansam>();
			hansam.gameObject.SetActive(false);
			hansam.Player = PlayerManager.Instance.Player.transform;
			m_hansams.Add(hansam);
		}
	}
}
