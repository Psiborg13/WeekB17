using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {
	float direction;
	int ticks = 1500;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < 15 && transform.position.x > -15) {
			direction = Input.GetAxis ("Horizontal");
			transform.position = new Vector3 (transform.position.x + ticks/1500 * 8F * Time.deltaTime * direction, transform.position.y, transform.position.z);
		} else if (transform.position.x > 15) {
			transform.position = new Vector3 (transform.position.x + ticks/1500 * 8F * Time.deltaTime * -1, transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (transform.position.x + ticks/1500 * 8F * Time.deltaTime, transform.position.y, transform.position.z);
		}
		if(ticks<6000){
			ticks++;
		}
	}
}
