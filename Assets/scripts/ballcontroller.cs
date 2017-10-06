using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour {
	float speed;
	float lifetimer;
	// Use this for initialization
	void Start () {
		lifetimer = 0;
		speed = 4.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += this.transform.forward * speed * Time.deltaTime;
		lifetimer += Time.deltaTime;
		if (lifetimer > 10) {
			Destroy (this.gameObject);
		}
	}
		void OnTriggerEnter(Collider other){
			if(other.gameObject.tag=="groundwhite"){
				Destroy(this.gameObject);
		}
		if (speed <= 10) {
			speed += Time.deltaTime / 60.0f;
		}
	}
}
