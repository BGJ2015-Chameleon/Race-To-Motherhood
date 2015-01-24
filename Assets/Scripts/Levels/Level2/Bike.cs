using UnityEngine;
using System.Collections;

public class Bike : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	float clamp(float v, float min, float max){
		if (v < min) {
			return min;
		} else if (v > max) {
			return max;
		}
		return v;
	}

	void Move(){
		Vector3 gyro = Input.gyro.rotationRate;
		gyro.x = 0;
		transform.Translate (gyro/10);
		Vector3 pos = transform.localPosition;
		float clamped = clamp (pos.y, -2, 2);
		pos.y = clamped;
		transform.localPosition = pos;
	}

}
