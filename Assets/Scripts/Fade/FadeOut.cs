using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour , IFadeAction {
	
	public void OnEnter(Fade.FadeInfo arg_fadeInfo) {
		arg_fadeInfo.m_currentAlpha = Fade.FadeInfo.ZERO;

		Color color = arg_fadeInfo.m_fadeObject.color;
		color.a = arg_fadeInfo.m_currentAlpha;

		arg_fadeInfo.m_fadeObject.color = color;
	}

	public void UpdateByFrame(Fade.FadeInfo arg_fadeInfo) {
		Color color = arg_fadeInfo.m_fadeObject.color;

		color.a = arg_fadeInfo.m_currentAlpha + Time.deltaTime / arg_fadeInfo.m_duration;
		arg_fadeInfo.m_fadeObject.color = color;
		arg_fadeInfo.m_currentAlpha = arg_fadeInfo.m_fadeObject.color.a;
	}

	public bool IsEnd(Fade.FadeInfo arg_fadeInfo) {
		return arg_fadeInfo.m_currentAlpha >= 0.99f;
	}
	
	public void OnExit(Fade.FadeInfo arg_fadeInfo) {
		arg_fadeInfo.m_currentAlpha = Fade.FadeInfo.MAX;
	}
}