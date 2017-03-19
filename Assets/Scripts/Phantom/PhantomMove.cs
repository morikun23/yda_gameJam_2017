using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomMove : MonoBehaviour , IPhantomState{

	public void OnEnter(Phantom arg_phantom) {

	}

	public void OnUpdate(Phantom arg_phantom) {

	}

	public void OnExit(Phantom arg_phantom) {

	}

	public PlayerBase.State GetCurrentState() {
		return PlayerBase.State.Move;
	}
}
