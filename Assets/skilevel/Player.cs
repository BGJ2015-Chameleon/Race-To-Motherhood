using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpDuration;

	private bool isJumping;

	void Start () {
		Input.gyro.enabled = true;
		isJumping = false;
	}

	float clamp(float v, float min, float max){
		if (v < min) {
				return min;
		} else if (v > max) {
			return max;
		}
		return v;
	} 

	void Update () {

		Move ();


	}

	void Move(){
		Vector3 gyro = Input.gyro.rotationRate;
		gyro.x = gyro.y;
		gyro.y = 0;
		gyro.z = 0;
		transform.Translate (gyro/10);
		Vector3 pos = transform.localPosition;
		float clamped = clamp (pos.x, -2, 2);
		pos.x = clamped;
		transform.localPosition = pos;
	}


	void OnTriggerEnter2D(Collider2D other){
		switch (other.name) {
		case "Jump":
			Jump();
			break;
		}
	}

	void Jump(){

		isJumping = true;

	}
}
