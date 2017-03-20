using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreNo1, scoreNo2, scoreNo3;
    int i,rank1,rank2,rank3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*int high_score = (int)GameManager.Instance.GetKilledCount();
        high_score++;
        */
        int highScore = PlayerPrefs.GetInt("scoreNo1", 0);
    //    scoreNo1.text = "abcde";


        rank1 = 22;
        rank2 = 44;
        rank3 = 72;

        for (i = 1; i < 3; i++)
        {
            if (rank1 < rank2)
            {
                scoreNo1.text="rank1";
            }else if(rank2<rank1)
            {

            }
        }

	}
}
