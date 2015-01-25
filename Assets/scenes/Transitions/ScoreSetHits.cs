using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSetHits : MonoBehaviour {

	public Text hits;

	// Use this for initialization
	void Start () {
		print ("New screen");
		print (Score.crashes);
		hits.text = Score.crashes.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
