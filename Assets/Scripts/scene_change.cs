﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_change : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find("GameManager")) {
			Destroy(GameObject.Find("GameManager"));
		}
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
