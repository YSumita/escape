using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemusecontroller : MonoBehaviour {
	public GameObject player;
	public GameObject heal;
	GameObject[] basegrounds;
	GameObject[] allgrounds;
	Vector3 playerpos;
	Vector3 groundpos;
	Vector3 distance;
	float timer;
	bool groundfalltiming;
	bool groundbacktiming;
	public bool itemeffect;
	public bool circlelaunch;
	public bool juujilaunch;
	public bool straightlaunch;
	float straightx;
	float straightz;

	// Use this for initialization
	void Start () {
		basegrounds = GameObject.FindGameObjectsWithTag ("groundwhite");
		allgrounds = GameObject.FindGameObjectsWithTag ("groundwhite");

		timer = 0;
		groundfalltiming = true;
		groundbacktiming = true;
	}
	
	// Update is called once per frame
	void Update () {
		//赤床が落ちてるときには残りをallgroundにする
		if (groundfalltiming) {
			if (timer >= 30+Time.deltaTime) {
				allgrounds = GameObject.FindGameObjectsWithTag ("groundwhite");
				groundfalltiming = false;
			}
		}

		if (groundbacktiming) {
			if (timer >= 60+Time.deltaTime) {
				allgrounds = basegrounds;
				groundbacktiming = false;
			}
		}

		playerpos = player.transform.position;
		if (circlelaunch) {
				foreach (GameObject obj in allgrounds) {
					groundpos = obj.transform.position;
					distance = playerpos - groundpos;
					if(Vector3.Dot(distance,distance)<15){
					obj.GetComponent<groundcontroller> ().becomewhite = true;
					}
				
				}
			circlelaunch = false;
		}

		if (juujilaunch) {
			foreach (GameObject obj in allgrounds) {
				if ((obj.transform.position.x > playerpos.x - 1 && obj.transform.position.x <= playerpos.x + 1) || (obj.transform.position.z > playerpos.z - 1 && obj.transform.position.z <= playerpos.z + 1)) {
					obj.GetComponent<groundcontroller> ().becomewhite = true;
				}
			}
			juujilaunch = false;
		}

		if (straightlaunch) {
			float xx = playerpos.x;
			float zz = playerpos.z;
			float seppen = 1.5f*Mathf.Sqrt (straightx * straightx + straightz * straightz)/Mathf.Sqrt(straightx*straightx);
				foreach (GameObject obj in allgrounds) {
				float xxx = obj.transform.position.x;
				float zzz = obj.transform.position.z;

				if (zzz <= straightz * (xxx - xx) / straightx + zz + seppen && zzz >= straightz * (xxx - xx) / straightx + zz - seppen) {
					obj.GetComponent<groundcontroller> ().becomewhite = true;
				}

				}
			straightlaunch = false;
		}

		if (timer >= 80) {
			timer = 0;
			groundfalltiming = true;
			groundbacktiming = true;
		}
		timer += Time.deltaTime;

		if (itemeffect) {
			Instantiate (heal, this.transform.position, new Quaternion(0,0,0,0));
			itemeffect = false;
		}



	}
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "itemcircle") {
			itemeffect = true;
			circlelaunch = true;
			Destroy (col.gameObject);
		} 
		else if (col.gameObject.tag == "itemjuuji") {
			itemeffect = true;
			juujilaunch = true;
			Destroy (col.gameObject);
		} 
		else if (col.gameObject.tag == "itemstraight") {
			itemeffect = true;
			straightx = col.transform.forward.x;
			if (straightx == 0) {
				straightx += 0.0001f;
			}
			straightz = col.transform.forward.z;
			straightlaunch = true;
			Destroy (col.gameObject);
		} 
	}
}
