using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemoveScript : MonoBehaviour {
	float start;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y - 15 < Camera.main.ViewportToWorldPoint (new Vector3 (0f, -1f, transform.position.z)).y) {
			Destroy (gameObject);
			GameObject[] list = GameObject.FindGameObjectsWithTag ("Ball");
			if(list.GetLength(0) == 0){
				if(Time.time-start>5){
					print (start);
					SceneManager.LoadScene ("Scene3");
				}
			} else if (list.GetLength (0) == 1) {
				start = Time.time;
				GameObject.Destroy(GameObject.Find("Sun_Moon_Lillie"));
				removeEggs ();
				GameObject.Destroy (GameObject.Find("bottom_pokeball"));
				print (Time.time - start);
				if(Time.time-start>5){
					print ("thing "+start);
					SceneManager.LoadScene ("Scene3");
				}
			} else if (list.GetLength(0) == 2) {
				GameObject.Destroy (GameObject.Find("middle_pokeball"));
				removeEggs ();
			} else if (list.GetLength(0) == 3) {
				GameObject.Destroy (GameObject.Find("top_pokeball"));
				removeEggs ();
			}
		}
	}

	void removeEggs(){
		GameObject[] list = GameObject.FindGameObjectsWithTag ("Egg");
		foreach(GameObject g in list){
			GameObject.Destroy (g);
		}
	}
}
