using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tateidoucontroller : MonoBehaviour {
	GameObject[] guusuu;
	GameObject[] kisuu;
	float time;
	public Text cubefallingannounce;

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

		if (time > 45 && time < 47) {
			cubefallingannounce.text = "床が縦に動き出すよ！";
		} else if (time > 47 && time < 48) {
			cubefallingannounce.text = "3";
		} else if (time > 48 && time < 49) {
			cubefallingannounce.text = "2";
		} else if (time > 49 && time < 50) {
			cubefallingannounce.text = "1";
		}


		else if (time>=50) {
			
			float zmove = Mathf.Cos (time-50) * 2 * Time.deltaTime;
			for (int i = 0; i < 72; i++) {
				Vector3 posg = guusuu [i].transform.position;
				Vector3 posk = kisuu [i].transform.position;
				posg.z += zmove;
				posk.z -= zmove;
				guusuu [i].transform.position = posg;
				kisuu [i].transform.position = posk;

			}
			time += Time.deltaTime;
		}

	}
}
