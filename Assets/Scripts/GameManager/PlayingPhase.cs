using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingPhase : MonoBehaviour , IGamePhase {

	public void OnEnter(GameManager arg_gameManager) {
		foreach(Generator generator in FindObjectsOfType<Generator>()) {
			generator.Initialize();
		}
	}

	public void OnUpdate(GameManager arg_gameManager) {
		if (arg_gameManager.GetLimitTime() <= 0) {
			arg_gameManager.PhaseTransition(new FinishPhase());
		}
	}

	public void OnExit(GameManager arg_gameManager) {
		
	}

	public string GetCurrentPhase() {
		return "Playing";
	}
}
