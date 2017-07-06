using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigScript : MonoBehaviour {
	public float deathThreshold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		Vector2 vel = this.GetComponent<Rigidbody2D> ().GetPointVelocity (new Vector2(transform.position.x, transform.position.y));
		if (Mathf.Pow (Mathf.Pow (vel.x, 2) + Mathf.Pow (vel.y, 2), 0.5f) > deathThreshold) {
			Destroy (gameObject);
		}
	}
}
