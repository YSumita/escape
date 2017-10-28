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
	float root2 = Mathf.Sqrt (2);
	Vector2 joymove;
	// Use this for initialization
	void Start ()
	{
		refobj = GameObject.Find ("gamemanager");
		speed = 7.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Rotate (0, Time.deltaTime * 270, 0, Space.World);


		pos = this.transform.position;
		movex = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		movez = CrossPlatformInputManager.GetAxisRaw ("Vertical");
		joymove = new Vector2 (movex, movez);

			//ジョイスティックの最低変位を決める
			if (joymove.magnitude > 10 && joymove.magnitude < 50) {
				if(movez > movex * (root2-1)){
					if(movez > movex * (-1-root2)){
						if(movez < movex * (root2+1)){
							this.transform.position += new Vector3 (speed * Time.deltaTime/root2, 0, speed * Time.deltaTime/root2);
						}
						else{
							this.transform.position += new Vector3 (0, 0, speed * Time.deltaTime);
						}
					}
					else{
						if(movez > movex * (1-root2)){
							this.transform.position += new Vector3 (-speed * Time.deltaTime/root2, 0, speed * Time.deltaTime/root2);
						}
						else{
							this.transform.position += new Vector3 (-speed * Time.deltaTime,0,0);
						}
					}
				}

				else{
					if(movez > movex * (-root2-1)){
						if(movez > movex * (1-root2)){
							this.transform.position += new Vector3 (speed * Time.deltaTime,0,0);
						}
						else{
							this.transform.position += new Vector3 (speed * Time.deltaTime/root2, 0, -speed * Time.deltaTime/root2);
						}
					}
					else{
						if(movez < movex * (root2+1)){
							this.transform.position += new Vector3 (0, 0, -speed * Time.deltaTime);
						}
						else{
							this.transform.position += new Vector3 (-speed * Time.deltaTime/root2, 0, -speed * Time.deltaTime/root2);
						}
					}
				}
			}






		if (Input.GetKey ("up")&&Input.GetKey ("right")) {
			this.transform.position += new Vector3 (speed * Time.deltaTime/root2, 0, speed * Time.deltaTime/root2);
		}
		else if (Input.GetKey ("up")&&Input.GetKey ("left")) {
			this.transform.position += new Vector3 (-speed * Time.deltaTime/root2, 0, speed * Time.deltaTime/root2);
		}
		else if (Input.GetKey ("down")&&Input.GetKey ("right")) {
			this.transform.position += new Vector3 (speed * Time.deltaTime/root2, 0, -speed * Time.deltaTime/root2);
		}
		else if (Input.GetKey ("down")&&Input.GetKey ("left")) {
			this.transform.position += new Vector3 (-speed * Time.deltaTime/root2, 0, -speed * Time.deltaTime/root2);
		}
		else if (Input.GetKey ("up")) {
			this.transform.position += new Vector3 (0, 0, speed * Time.deltaTime);
		}
		else if (Input.GetKey ("down")) {
			this.transform.position -= new Vector3 (0, 0, speed * Time.deltaTime);
		}
		else if (Input.GetKey ("right")) {
			this.transform.position += new Vector3 (speed * Time.deltaTime,0,0);
		}
		else if (Input.GetKey ("left")) {
			this.transform.position -= new Vector3 (speed * Time.deltaTime,0,0);

		}

		if (this.transform.position.y < -5) {
			PlayerPrefs.SetInt ("lastscore", Mathf.FloorToInt(refobj.GetComponent<scorecalculator> ().score));
			SceneManager.LoadScene ("GameOverScene");
		}

	}



}
