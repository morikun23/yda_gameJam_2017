using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private static GameManager m_instance;

	public static GameManager Instance {
		get {
			if(m_instance == null) {
				m_instance = FindObjectOfType<GameManager>();
			}
			return m_instance;
		}
	}

	private GameManager() { }

	private int m_killedCount;

	private float m_bonusPower;

	private float m_limitTime;

	private IGamePhase m_currentPhase;

	PlayerManager m_playerManager;

	// Use this for initialization
	void Start () {
		Initialize();
		m_playerManager = PlayerManager.Instance;
		m_playerManager.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		
		m_playerManager.UpdateByFrame();

		if(GetCurrentPhase() == "Playing") {
			m_limitTime -= Time.deltaTime;
		}

		ConvertChargePower();

		m_currentPhase.OnUpdate(this);
	}

	public void PhaseTransition(IGamePhase arg_nextPhase) {
		m_currentPhase.OnExit(this);
		m_currentPhase = arg_nextPhase;
		m_currentPhase.OnEnter(this);
	}

	public void Initialize() {
		m_killedCount = 0;
		m_bonusPower = 1;
		m_limitTime = 60f;
		m_currentPhase = new IntroductionPhase();
		m_currentPhase.OnEnter(this);
	}

	public int GetKilledCount() {
		return m_killedCount;
	}

	public float GetChargedPower() {
		return m_bonusPower;
	}

	public float GetLimitTime() {
		return m_limitTime;
	}

	public string GetCurrentPhase() {
		return m_currentPhase.GetCurrentPhase();
	}

	public void AddKilledCount() {
		m_killedCount++;
	}

	private void ConvertChargePower() {
		float t = ((float)m_killedCount / 70);
		m_bonusPower = 1 + t;
	}
}