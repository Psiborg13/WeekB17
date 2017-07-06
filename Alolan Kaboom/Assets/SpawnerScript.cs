using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
	public GameObject obj;
	public GameObject shiny;
	public float delay = 30F;
	private float ticks;

	// Use this for initialization
	void Start () {
		ticks = delay;
	}
	
	// Update is called once per frame
	void Update () {
		if (ticks == delay) {
			GameObject madeObj;
			int chance = Random.Range (0, 4095);
			if (chance == 42 || chance == 13 || chance == 1) {
				madeObj = Instantiate (shiny);
			} else {
				madeObj = Instantiate (obj);
			}
			madeObj.transform.position = transform.position;
			ticks = 0;
		} else {
			ticks++;
		}
	}
}
