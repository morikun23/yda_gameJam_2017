using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreNo1, scoreNo2, scoreNo3;
    int i,rank1,rank2,rank3;

    int score;
    int nowScore;
    int buff;

	// Use this for initialization
	void Start () {
        nowScore = 0;
        buff = 0;
    }
	
	// Update is called once per frame
	void Update () {

        //今回のスコアの取得
        nowScore = GameManager.Instance.GetKilledCount();

        if (rank1 < nowScore) rank1 = nowScore;
        else if(rank2 < nowScore) rank2 = nowScore;
        else if (rank3 < nowScore) rank3 = nowScore;

        for (i = 0; i < 3; i++)
        {
            buff = rank1;
            //rank1 = 
        }

	}
}
