using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scorecalculator : MonoBehaviour {
	public float score;
	float rednum;
	float redrate;
	GameObject[] groundswhite;
	public float totaltilenum;
	public Text scoretext;
	// Use this for initialization
	void Start () {
		score = 0;
		totaltilenum = 144;
	}
	
	// Update is called once per frame
	void Update () {
		groundswhite = GameObject.FindGameObjectsWithTag ("groundwhite");
		rednum = totaltilenum-groundswhite.Length;
		redrate = rednum / totaltilenum;
		score += Time.deltaTime * redrate*10;
		scoretext.text = Mathf.FloorToInt(score).ToString ();
	}

	public float getredrate(){
		return redrate;
	}
}
