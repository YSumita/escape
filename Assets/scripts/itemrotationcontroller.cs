using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemrotationcontroller : MonoBehaviour {
	// Use this for initialization
	float timer;
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0,Time.deltaTime*270,0,Space.World);
		timer += Time.deltaTime;

		if (timer >= 20) {
			Destroy (this.gameObject);
		}
	}
}
