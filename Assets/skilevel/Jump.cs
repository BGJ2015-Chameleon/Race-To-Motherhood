using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	// Use this for initialization
	void Start () {
		name = "Jump";
	}

	void OnTriggerEnter2D(Collider2D other){
		audio.Play ();
	}
}
