using UnityEngine;
using System.Collections;

public class Level2_Goal : MonoBehaviour {

	private float t = 0;
	private bool levelDone = false;
	void Update(){
		if (!levelDone) {
			return;
		}
		
		t += Time.deltaTime;
		if (t > 2) {
			Application.LoadLevel("EndTransition");
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		levelDone = true;
		Score.EndTimer ();
	}
}
