using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamcontroller : MonoBehaviour {

	public GameObject speedball;
	GameObject speedballadjust;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		speedballadjust = Instantiate (speedball, this.transform.position, this.transform.rotation);
		speedballadjust.transform.Rotate (0, 90, 0);
	}
}
