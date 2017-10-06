using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemtateidoucontroller : MonoBehaviour {
	GameObject[] guusuu;
	GameObject[] kisuu;
	float time;

	// Use this for initialization
	void Start () {
		time = 0;
		guusuu = new GameObject[72];
		kisuu = new GameObject[72];
		for (int i = 0; i < 72; i++) {
			kisuu[i]=GameObject.Find("/cubefolder/Cube ("+(2*i+1)+")");
			guusuu[i]=GameObject.Find("/cubefolder/Cube ("+(2*i+2)+")");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		float zmove = Mathf.Cos (time) *2*Time.deltaTime;
		for(int i=0;i<72;i++) {
			Vector3 posg = guusuu[i].transform.position;
			Vector3 posk = kisuu[i].transform.position;
			posg.z += zmove;
			posk.z -= zmove;
			guusuu[i].transform.position = posg;
			kisuu[i].transform.position = posk;

		}
		time+=Time.deltaTime;
	}
}
