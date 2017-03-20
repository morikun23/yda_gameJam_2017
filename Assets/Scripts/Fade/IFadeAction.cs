using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFadeAction {

	void OnEnter(Fade.FadeInfo arg_fadeInfo);
	void UpdateByFrame(Fade.FadeInfo arg_fadeInfo);
	bool IsEnd(Fade.FadeInfo arg_fadeInfo);
	void OnExit(Fade.FadeInfo arg_fadeInfo);
}