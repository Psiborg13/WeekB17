using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CatchScript : MonoBehaviour {
	public GameObject text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Egg") {
			text.GetComponent<Text>().text=(Int32.Parse(text.GetComponent<Text>().text)+1)+"";
			Destroy (col.gameObject);
		}
	}
}
