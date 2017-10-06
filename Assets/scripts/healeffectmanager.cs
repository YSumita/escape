using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healeffectmanager : MonoBehaviour {

	float timer;
	// Use this for initialization
	void Start () {
		timer = 0;

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 1) {
			Destroy (this.gameObject);
		}


	}
}
