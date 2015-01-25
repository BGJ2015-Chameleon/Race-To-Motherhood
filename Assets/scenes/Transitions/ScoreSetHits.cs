using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSetHits : MonoBehaviour {

	public Text hits;
	
	// Update is called once per frame
	void Update () {
		hits.text = Score.crashes.ToString ();
	
	}
}
