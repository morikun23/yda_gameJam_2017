using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour {

	public enum State {
		Move,//動いてる状態
		Charge,//スタンドを飛ばしている状態
		Attacking,//スタンドとどっきんぐ中☆
		Dameging//硬直なう

	}

	protected State state;

	//ドッキングポジション
	public Vector3 centerPosition;

	//攻撃範囲
	protected float attackArea;
}
