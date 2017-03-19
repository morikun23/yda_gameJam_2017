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

	private int m_bonusPower;

	private float m_limitTime;

	private IGamePhase m_currentPhase;

	// Use this for initialization
	void Start () {
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
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
		m_limitTime = 30f;
		m_currentPhase = new IntroductionPhase();
		m_currentPhase.OnEnter(this);
	}

	public int GetKilledCount() {
		return m_killedCount;
	}

	public int GetChargedPower() {
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
		//プレイヤーのチャージ力を取得する
	}
}