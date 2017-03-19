
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_limit : MonoBehaviour
{

    Text text;
    

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        int time = (int)GameManager.Instance.GetLimitTime();
        text.text = time.ToString();
    }
}
