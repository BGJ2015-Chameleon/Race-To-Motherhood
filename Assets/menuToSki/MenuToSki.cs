using UnityEngine;
using System.Collections;

public class MenuToSki : MonoBehaviour {

	private float t;

	// Use this for initialization
	void Start () {
//		t = 5;
//		guiText.text = "Get ready: 5";
	}



	// Update is called once per frame
	void Update () {
//		print ("test");
//		float dt = Time.deltaTime;
//		t -= dt;
//		if (t < 0) {
			Application.LoadLevel("skilevel");
//		}
//		guiText.text = "Get ready: " + Mathf.CeilToInt (t);
	}
}
