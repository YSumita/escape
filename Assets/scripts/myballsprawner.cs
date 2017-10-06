using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myballsprawner : MonoBehaviour {

	public GameObject ball;
	public float ballleft;
	private float balltimer;
	private float ballmax;
	public Image ballleftImage;
	void Start () {
		ballmax = 5;
		ballleft = 5;
		balltimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			if (ballleft > 0) {
				Instantiate (ball, this.transform.position + this.transform.forward, this.transform.rotation);
				ballleft--;
				ballleftImage.fillAmount = ballleft / ballmax;
			}		

		}
		balltimer += Time.deltaTime;
		if (balltimer > 3) {
			if (ballleft < 5) {
				ballleft++;
				ballleftImage.fillAmount = ballleft / ballmax;
			}
			balltimer = 0;
		}
	}
}
