using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class playercontroller : MonoBehaviour
{
	Vector3 pos;
	float speed;
	GameObject refobj;
	float movex;
	float movez;

	// Use this for initialization
	void Start ()
	{
		refobj = GameObject.Find ("gamemanager");
		speed = 6.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Rotate (0, Time.deltaTime * 270, 0, Space.World);


//		pos = this.transform.position;
//		movex = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
//		movez = CrossPlatformInputManager.GetAxisRaw ("Vertical");
//
//		if (movez > movex) {
//			if (movez > -movex) {
//				pos.z += speed * Time.deltaTime;
//			} else {
//				pos.x -= speed * Time.deltaTime;
//			}
//		} else if (movez < movex) {
//			if (movez > -movex) {
//				pos.x += speed * Time.deltaTime;
//			} else {
//				pos.z -= speed * Time.deltaTime;
//			}
//		}
//
//		pos.z += speed * Time.deltaTime * CrossPlatformInputManager.GetAxisRaw ("Vertical");
////		this.transform.position = pos;

		if (Input.GetKey ("up")) {
			this.transform.position += new Vector3 (0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey ("down")) {
			this.transform.position -= new Vector3 (0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey ("right")) {
			this.transform.position += new Vector3 (speed * Time.deltaTime,0,0);
		}
		if (Input.GetKey ("left")) {
			this.transform.position -= new Vector3 (speed * Time.deltaTime,0,0);

		}
		if (this.transform.position.y < -5) {
			PlayerPrefs.SetInt ("lastscore", Mathf.FloorToInt(refobj.GetComponent<scorecalculator> ().score));
			SceneManager.LoadScene ("GameOverScene");
		}

	}



}
