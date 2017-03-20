using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text scoreNo1, scoreNo2, scoreNo3;
	int i,rank1,rank2,rank3;

    int score;
    int nowScore;
    int buff;

	int[] ranks;

	// Use this for initialization
	void Start () {

		ranks = new int[4];

        nowScore = 0;
        buff = 0;

		scoreNo1 = GameObject.Find("1st (1)").GetComponent<Text>();
		scoreNo2 = GameObject.Find("1st (2)").GetComponent<Text>();
		scoreNo3 = GameObject.Find("1st (3)").GetComponent<Text>();


		ranks[0]= PlayerPrefs.GetInt("score1",0);
		ranks[1] = PlayerPrefs.GetInt("score2",0);
		ranks[2] = PlayerPrefs.GetInt("score3",0);
		ranks[3] = GameManager.Instance.GetKilledCount();

		for (int i = 0; i < ranks.Length - 1; i++) {
			for (int j = i + 1; j < ranks.Length; j++) {
				if (ranks[i] < ranks[j]) {
					int temp = ranks[i];
					ranks[i] = ranks[j];
					ranks[j] = temp;
				}
			}
		}


		scoreNo1.text = ranks[0].ToString();
		scoreNo2.text = ranks[1].ToString();
		scoreNo3.text = ranks[2].ToString();

		PlayerPrefs.SetInt("score1" , ranks[0]);
		PlayerPrefs.Save();
		PlayerPrefs.SetInt("score2" , ranks[1]);
		PlayerPrefs.Save();
		PlayerPrefs.SetInt("score3" , ranks[2]);
		PlayerPrefs.Save();

	}
	
	// Update is called once per frame
	void Update () {
		
        

		

	}
}
