using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotScript : MonoBehaviour {
	public GameObject bird1;
	public GameObject bird2;
	public GameObject bird3;
	private GameObject bird;
	private int ticks;
	public int maxTicks;
	public int xSpeedScale;
	public int ySpeedScale;
	private bool birdLoaded;
	private bool birdLaunching;

	void Start () {
		transform.GetChild (0).gameObject.SetActive (false);
		bird = bird1;
		bird2.GetComponent<BoxCollider2D> ().enabled = false;
		bird2.GetComponent<Rigidbody2D> ().simulated = false;
		bird3.GetComponent<BoxCollider2D> ().enabled = false;
		bird3.GetComponent<Rigidbody2D> ().simulated = false;
		birdLoaded = false;
		birdLaunching = false;
	}

	void Update () {
		if (birdLoaded) {
			bird.GetComponent<Rigidbody2D> ().isKinematic = true;
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouse = new Vector3 (constrict (mouse.x, -7.7f, 0f), constrict (mouse.y, -3.5f, 0f), 0f);
			if (Mathf.Pow (Mathf.Pow (mouse.x - transform.position.x, 2f) + Mathf.Pow (mouse.y - transform.position.y, 2f), 0.5f) < 3f) {
				bird.transform.position = mouse;
			} 
		} else if (!birdLoaded && bird.GetComponent<Rigidbody2D> ().isKinematic) {
			bird.GetComponent<Rigidbody2D> ().isKinematic = false;
			bird.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xSpeedScale * (transform.GetChild (0).position.x - bird.transform.position.x), 
				ySpeedScale * (transform.GetChild (0).position.y - bird.transform.position.y));
		} else if (!birdLoaded && !bird.GetComponent<Rigidbody2D> ().isKinematic && birdLaunching) {
			Vector2 vel = bird.GetComponent<Rigidbody2D> ().velocity;
			if (Mathf.Pow (Mathf.Pow (vel.x, 2) + Mathf.Pow (vel.y, 2), 0.5f) < 0.75f || Mathf.Abs(bird.transform.position.x) > 9) {
				ticks++;
				if(ticks >= maxTicks || Mathf.Abs(bird.transform.position.x) > 9){
					bird.GetComponent<BoxCollider2D> ().enabled = false;
					bird.GetComponent<Rigidbody2D> ().simulated = false;
					Destroy (bird.gameObject);
					if (bird == bird1) {
						bird = bird2;
						bird.GetComponent<BoxCollider2D> ().enabled = true;
						bird.GetComponent<Rigidbody2D> ().simulated = true;
					} else if (bird == bird2) {
						bird = bird3;
						bird.GetComponent<BoxCollider2D> ().enabled = true;
						bird.GetComponent<Rigidbody2D> ().simulated = true;
					} else if(bird == bird3){
						Destroy (bird.gameObject);
						Destroy (this);
					}
					birdLaunching = false;
				}
			} else {
				ticks = 0;
			}
		}
	}
		
	void OnMouseEnter(){
		if (!birdLoaded && !birdLaunching) {
			transform.GetChild (0).gameObject.SetActive (true);
		}
	}

	void OnMouseExit(){
		if (!birdLoaded) {
			transform.GetChild (0).gameObject.SetActive (false);
		}
	}
		
	void OnMouseDown(){
		if (!birdLoaded && !birdLaunching) {
			bird.transform.position = transform.position;
			birdLoaded = true;
			transform.GetChild (0).gameObject.SetActive (false);
		} 
	}

	void OnMouseUp(){
		if (birdLoaded && !birdLaunching) {
			birdLoaded = false;
			birdLaunching = true;
		}
	}

	private float constrict(float input, float min, float max){
		if (input < min) {
			return min;
		} else if (input > max) {
			return max;
		} else {
			return input;
		}
	}
}
