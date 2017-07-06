using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CosmogRemove : MonoBehaviour {
	float start;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y - 10 < Camera.main.ViewportToWorldPoint (new Vector3 (0f, -1f, transform.position.z)).y) {
			Destroy (gameObject);
			GameObject[] list = GameObject.FindGameObjectsWithTag ("Ball");
			if (list.GetLength (0) == 0) {
				if(Time.time - start > 5){
					SceneManager.LoadScene ("Scene3");
				}
			} else if (list.GetLength (0) == 1) {
				GameObject.Destroy (GameObject.Find("bottom_pokeball"));
				removeEggs ();
				start = Time.time;
				if(Time.time - start > 5){
					print ("spleen");
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
