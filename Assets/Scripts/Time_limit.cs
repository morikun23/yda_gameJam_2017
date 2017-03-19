/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_limit : MonoBehaviour
{

    Text text;
    GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        gameManager = GameObject.Find("GameManeger").GetComponent<Gamemaneger>();
    }

    // Update is called once per frame
    void Update()
    {
        int time = (int)gameManager.GetLimitTime();
        text.text = time.ToString();
    }
}
*/