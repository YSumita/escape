using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmscript : MonoBehaviour {

	public static GameObject instance;

	void Awake ()
	{
		if (instance == null) {
			instance = this.gameObject;
			DontDestroyOnLoad (this.gameObject);
		} 
		else {
			Destroy (this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
