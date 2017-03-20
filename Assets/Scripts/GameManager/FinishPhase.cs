using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishPhase : MonoBehaviour , IGamePhase {

	private Text m_gameText;

	private float m_elapsedTime;

	public void OnEnter(GameManager arg_gameManager) {
		m_gameText = GameObject.Find("GameText").GetComponent<Text>();
	}

	public void OnUpdate(GameManager arg_gameManager) {
		m_gameText.text = "しゅ～りょ～！";
		m_gameText.color = Color.yellow;

		arg_gameManager.m_playerManager.UpdateByFrame();

		m_elapsedTime += Time.deltaTime;

		if(m_elapsedTime >= 1.5f) {
			SceneTransition();
			arg_gameManager.PhaseTransition(new ResultPhase());
		}
	}

	public void OnExit(GameManager arg_gameManager) {
		
	}

	public string GetCurrentPhase() {
		return "Finish";
	}

	private void SceneTransition() {
		//テキストクリア
		m_gameText.text = "";

        SceneManager.LoadScene("Result");
        
	}
}
