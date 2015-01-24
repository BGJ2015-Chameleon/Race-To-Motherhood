using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpDuration;

	public float speed;
	public float accel;

	private float currentSpeed;

	private bool isJumping;
	private float tJumpLeft;
	private GameObject camera;

	void Start () {
		Input.gyro.enabled = true;
		isJumping = false;

		currentSpeed = speed;
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
		float dt = Time.deltaTime;

		transform.parent.Translate(0, -dt*currentSpeed, 0);
		currentSpeed += (accel/10)*dt;

		if (!isJumping) {
			Move ();
		} else {
			tJumpLeft -= dt;
			isJumping = tJumpLeft > 0;
			if(!isJumping){
				transform.Find ("TrailLeft").GetComponent<TrailRenderer> ().enabled = true;
				transform.Find ("TrailRight").GetComponent<TrailRenderer> ().enabled = true;
				rigidbody2D.WakeUp();

			}
		}
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
				if (!isJumping) {
						Jump ();
				}
				break;
			case "Bush":
				if (isJumping) {
						// points?
				} else {
						currentSpeed /= 2;
				}
				break;
			case "Tree":
			currentSpeed /= 4;
				break;
		}
	}

	void Jump(){
		audio.Play ();
		isJumping = true;
		tJumpLeft = jumpDuration;
		transform.Find ("TrailLeft").GetComponent<TrailRenderer> ().enabled = false;
		transform.Find ("TrailRight").GetComponent<TrailRenderer> ().enabled = false;
	}
}
