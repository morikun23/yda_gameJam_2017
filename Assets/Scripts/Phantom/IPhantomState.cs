using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhantomState{

	void OnEnter(Phantom arg_phantom);
	void OnUpdate(Phantom arg_phantom);
	void OnExit(Phantom arg_phantom);
	PlayerBase.State GetCurrentState();
}
