using UnityEngine;
using System.Collections;

public class SkiGoal : MonoBehaviour {
	

	private float t = 0;
	private bool levelDone = false;
	void Update(){
		if (!levelDone) {
			return;
		}

		t += Time.deltaTime;
		if (t > 2) {
			Application.LoadLevel("Level1Level2");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		levelDone = true;
	}
}
