using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
	
	public class FadeInfo {
		//Fadeに使用するImageコンポーネント
		public Image m_fadeObject;
		//α値の上限
		public const byte MAX = 1;
		//α値の下限
		public const byte ZERO = 0;
		//フェードにかける時間
		public float m_duration;
		//現在のα値
		public float m_currentAlpha;
	}

	private FadeInfo m_fadeInfo;

	public bool isActive { get; private set; }
	
	private IFadeAction m_fadeAction;

	public void Initialize() {
		m_fadeInfo = new FadeInfo();
		m_fadeInfo.m_fadeObject = GetComponent<Image>();
		isActive = false;
		Clear();
	}
	
	public void StartFade(IFadeAction arg_fadeAction , Color arg_color , float arg_duration) {
		m_fadeAction = arg_fadeAction;
		m_fadeInfo.m_duration = arg_duration;
		m_fadeInfo.m_fadeObject.color = arg_color;
		m_fadeAction.OnEnter(this.m_fadeInfo);
		isActive = true;
	}

	public void UpdateByFrame() {
		
		if (m_fadeAction.IsEnd(this.m_fadeInfo)) {
			m_fadeAction.OnExit(this.m_fadeInfo);
			isActive = false;

			return;
		}
		m_fadeAction.UpdateByFrame(this.m_fadeInfo);
	}
	
	public void Clear() {
		m_fadeInfo.m_fadeObject.color = Color.clear;
	}

	public void Fill(Color arg_color) {
		m_fadeInfo.m_fadeObject.color = arg_color;
	}
}