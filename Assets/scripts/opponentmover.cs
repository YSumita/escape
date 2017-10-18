using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentmover : MonoBehaviour {
	Vector3 firstposition;
	//Vector3 sideway;
	Vector3 rotation;
	Vector3 down=new Vector3(0,0.5f,0);
	public GameObject player;
	float timer;
	float x;
	float y;
	float z;

	public GameObject redball;
	public GameObject purpleball;
	float ballsprawn;
	float ballkatamuki;
	float ballmax;
	float beamrate;
	float time;
	float timecycle;

	bool usual;
	float tame;
	public GameObject laserbeam;
	int beamarea;
	AudioSource audiosource;
	public AudioClip beamsound;
	bool beameffect;
	bool beamexist;

	// Use this for initialization
	void Start () {
		firstposition = this.transform.position;
		timer = 0;
		time = 0;
		ballsprawn = 0.005f;
		usual = true;
		audiosource = this.gameObject.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("stagenum") == 1) {
			ballsprawn = 0.005f;
			ballkatamuki = 1 / 5000f;
			ballmax = 0.06f;
			beamexist = false;
		}
		else if (PlayerPrefs.GetInt ("stagenum") == 2) {
			ballsprawn=0.005f;
			ballkatamuki = 1 / 2500f;
			ballmax = 0.06f;
			beamexist = true;
			beamrate = 0.0004f;
			timecycle = 40f;
		}
		else if (PlayerPrefs.GetInt ("stagenum") == 3) {
			ballsprawn=0.1f;
			ballkatamuki = 1 / 5000f;
			ballmax = 0.2f;
			beamexist = true;
			beameffect = true;
			beamrate = 0.001f;
			timecycle = 20f;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (usual) {
			timer += Time.deltaTime;
			if (firstposition.x < 0) {
				x = -8 * Mathf.Sin (-timer);
				y = 4.5f + Mathf.Sin (3 * (-timer));
				z = -8 * Mathf.Cos (-timer);
				Vector3 newpos = new Vector3 (x, y, z);
				this.transform.position = newpos;
			} else {
				x = 8 * Mathf.Sin (timer);
				y = 4.5f + Mathf.Sin (3 * timer);
				z = 8 * Mathf.Cos(timer);
				Vector3 newpos = new Vector3 (x, y, z);
				this.transform.position = newpos;
			}
			this.transform.LookAt (player.transform.position - down);
	
			if (Random.Range (0.0f, 1.0f) < ballsprawn) {
				if (time <= timecycle-10) {
					Instantiate (redball, this.transform.position + this.transform.forward, this.transform.rotation);
				} else {
					Instantiate (purpleball, this.transform.position + this.transform.forward, this.transform.rotation);
				}
			}
			if (ballsprawn < ballmax) {
				ballsprawn += Time.deltaTime*ballkatamuki;
			}
			if (ballsprawn >= ballmax && ballsprawn < ballmax+0.02f) {
				ballsprawn += Time.deltaTime*ballkatamuki*2;
			}

			time += Time.deltaTime;
			if (time >= timecycle) {
				time = 0;
				beameffect = true;
			}
	
			if (beamexist&&beameffect) {
				if (Random.Range (0.0f, 1.0f) < beamrate) {
					StartCoroutine ("Beam");
				}
			}
		}
	}

	IEnumerator Beam() {
		usual = false;
		tame = 0;
		audiosource.PlayOneShot (beamsound);
		while (tame < 1) {
			this.transform.Rotate (1f, 0, 0);
			tame += Time.deltaTime;
			yield return null;
		}
		GameObject newbeam = Instantiate (laserbeam, this.transform.position + this.transform.forward, Quaternion.Euler (0f, 0f, -90f));
		newbeam.transform.parent=this.transform;

		for(int i=1;i<70;i++){
			this.transform.Rotate(-1.3f,0,0);
			yield return null;
		}
		Destroy (newbeam);
		usual = true;
		yield break;


	}

}
