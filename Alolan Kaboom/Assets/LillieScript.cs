using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LillieScript : MonoBehaviour {
	float chance = 6f;
	int ticks = 1000;
	int direction = 1;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x+ticks/1000*3F*Time.deltaTime*direction, transform.position.y, transform.position.z);
		if(Mathf.Abs(transform.position.x)>8 || Random.Range(0F, 100F) < chance-ticks/1000){
			direction *= -1;
		}
		if(ticks<6000){
			ticks++;
		}
	}
}
