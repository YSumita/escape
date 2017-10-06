using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedballscript : MonoBehaviour {
	float lifetimer;
	// Use this for initialization
	void Start () {
		lifetimer = 0;
		this.gameObject.GetComponent<Rigidbody> ().velocity = this.transform.forward * 100;
	}
	
	// Update is called once per frame
	void Update () {
		lifetimer += Time.deltaTime;
		if (lifetimer >= 0.5) {
			Destroy (this.gameObject);
		}

	}
}
