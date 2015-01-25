using UnityEngine;
using System.Collections;

public class level2_alert : MonoBehaviour {
	float seconds;
	SpriteRenderer sr;
	Bike bike;

	// Use this for initialization
	void Start () {
//		seconds = 0;
		sr = GetComponent <SpriteRenderer> ();
		bike = GetComponentInParent <Bike> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(bike.isInDanger()){
			sr.color = new Color(1f, 1f, 1f, 1f);
		}
		else {
			sr.color = new Color(1f, 1f, 1f, 0f);
		}
//		float dt = Time.deltaTime;
//		seconds +=  Time.deltaTime;
//
//		//Debug.Log (seconds);
//
//		if(seconds >= 10){
//
//			sr.color = new Color(1f, 1f, 1f, 1f);
//			AlertIsEngaged();
//		}
//
//		if(seconds >= 12){
//			bike.FailedQuickTimeEvent ();
//			sr.color = new Color(1f, 1f, 1f, 0f);
//			seconds = 0;
//		}
	}

//	void AlertIsEngaged(){
//
//
//		if (Input.touchCount > 0){
//			bike.Switch();
//			sr.color = new Color(1f, 1f, 1f, 0f);
//			seconds = 0;
//		}
//	}
}
