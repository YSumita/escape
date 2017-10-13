﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour {

	// Use this for initialization
	public bool DontDestroyEnabled = true;

	// Use this for initialization
	void Start () {
		if (DontDestroyEnabled) {
			// Sceneを遷移してもオブジェクトが消えないようにする
			DontDestroyOnLoad (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
