using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Generator : MonoBehaviour {

	[SerializeField]
	private float m_interval;

	[SerializeField]
	private GameObject m_hansamPrefab;

	[SerializeField]
	private int m_max;

	private List<Hansam> m_hansams;

	// Use this for initialization
	void Start () {
		m_hansams = new List<Hansam>();
		Initialize();
		StartCoroutine(Exec());
	}
	
	private IEnumerator Exec() {
		while (true) {
			
			yield return new WaitForSeconds(m_interval);

			List<Hansam> activeHansams =
				m_hansams.Where(_ => !_.gameObject.activeInHierarchy).ToList();
			foreach (Hansam hansam in activeHansams) {
				hansam.gameObject.SetActive(true);
				hansam.transform.position = this.transform.position;
				break;
			}
		}
	}

	public void Initialize() {
		for(int i = 0; i < m_max; i++) {
			Hansam hansam = Instantiate(m_hansamPrefab ,
				transform.position , Quaternion.identity).GetComponent<Hansam>();
			hansam.gameObject.SetActive(false);

			m_hansams.Add(hansam);
		}
	}
}
