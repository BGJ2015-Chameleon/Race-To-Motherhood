using UnityEngine;
using System.Collections;

public class EndTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToCredits(){
		Application.LoadLevel("Credits");
	}
}
