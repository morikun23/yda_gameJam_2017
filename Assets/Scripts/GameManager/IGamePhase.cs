using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGamePhase {

	void OnEnter(GameManager arg_gameManager);
	void OnUpdate(GameManager arg_gameManager);
	void OnExit(GameManager arg_gameManager);
	string GetCurrentPhase();
}
