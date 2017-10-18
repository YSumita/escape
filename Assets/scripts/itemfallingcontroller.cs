using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemfallingcontroller : MonoBehaviour {
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;
	GameObject[] whitegrounds;
	GameObject instantiateitem;
	int whiteballnum;
	Vector3 cubeposition;
	Vector3 cuberotation;
	float itemrate;
	float itemkatamuki;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("stagenum") == 1) {
			itemrate = 0.0015f;
			itemkatamuki = 1 / 18000f;
		}
		else if (PlayerPrefs.GetInt ("stagenum") == 2) {
			itemrate = 0.003f;
			itemkatamuki = 1 / 9000f;
		}
		else if (PlayerPrefs.GetInt ("stagenum") == 3) {
			itemrate = 0.025f;
			itemkatamuki = 0;
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(itemrate<0.025){
			itemrate += Time.deltaTime*itemkatamuki;
		}
		if (Random.Range(0.0f,1.0f)<itemrate) {
			whitegrounds = GameObject.FindGameObjectsWithTag ("groundwhite");
			whiteballnum = Random.Range (0, whitegrounds.Length);

			if (Random.Range (0.0f, 1.0f) < 0.333) {
				instantiateitem = item1;
			}
			else if (Random.Range (0.0f, 1.0f) < 0.5) {
				instantiateitem = item2;
			}
			else {
				instantiateitem = item3;
			}
			Instantiate (instantiateitem, whitegrounds [whiteballnum].transform.position+new Vector3(0,1,0), whitegrounds [whiteballnum].transform.rotation);
		}

	}
}
