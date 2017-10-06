using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purpleballcontroller : MonoBehaviour {
	float speed;
	float lifetimer;
	GameObject player;
	Vector3 playerpos;
	Vector3 way;

	// Use this for initialization
	void Start () {
		lifetimer = 0;
		speed = 4.0f;
		player=GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		playerpos = player.transform.position-new Vector3(0,1,0);
		way = (playerpos - this.transform.position).normalized;
		this.transform.position += way * speed * Time.deltaTime;
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
