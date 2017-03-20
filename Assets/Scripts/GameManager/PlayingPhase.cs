using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingPhase : MonoBehaviour , IGamePhase {

	public void OnEnter(GameManager arg_gameManager) {

		Sound bgm = new Sound(Vector2.zero , BGM.Battle);
		bgm.audioSource.loop = true;
		bgm.audioSource.Play();

		foreach (Generator generator in FindObjectsOfType<Generator>()) {
			generator.Initialize();
		}
	}

	public void OnUpdate(GameManager arg_gameManager) {

		arg_gameManager.m_playerManager.UpdateByFrame();

		if (arg_gameManager.GetLimitTime() <= 0) {
			arg_gameManager.PhaseTransition(new FinishPhase());
		}

        if (arg_gameManager.GetKilledCount() == 15)
        {
            foreach (Generator generator in FindObjectsOfType<Generator>())
            {
                generator.Generate(1);
            }
        }

        if (arg_gameManager.GetKilledCount() == 30)
        {
            foreach (Generator generator in FindObjectsOfType<Generator>())
            {
                generator.Generate(1);
            }
        }
    }

	public void OnExit(GameManager arg_gameManager) {
		
	}

	public string GetCurrentPhase() {
		return "Playing";
	}
}
