using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionPhase : MonoBehaviour , IGamePhase {

	private Text m_countDownText;

	private float m_countDownTime;


	public void OnEnter(GameManager arg_gameManager) {
		//カウントダウンスタート
		m_countDownText = GameObject.Find("GameText").GetComponent<Text>();
		m_countDownText.color = Color.white;
		m_countDownTime = 4f;
	}

	public void OnUpdate(GameManager arg_gameManager) {
		//カウントダウン中
		m_countDownTime -= Time.deltaTime;


		if((int)m_countDownTime > 0) {
			//カウントダウンの時間を表示
			m_countDownText.text = ((int)m_countDownTime).ToString();
		}
		else if (m_countDownTime >= 0) {
			m_countDownText.text = "すた～と！";
			m_countDownText.color = Color.yellow;
		}
		else {
			arg_gameManager.PhaseTransition(new PlayingPhase());
		}
		
	}

	public void OnExit(GameManager arg_gameManager) {
		//テキストクリア
		m_countDownText.text = "";
	}

	public string GetCurrentPhase() {
		return "Introduction";
	}
}
