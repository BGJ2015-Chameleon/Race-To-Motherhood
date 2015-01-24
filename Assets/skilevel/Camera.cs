using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float speed;
	public float accel;
	private float time;
	private float currentSpeed;


	void Start() {
		time = 0;
		currentSpeed = speed;
	}

	void Update () {
		float dt = Time.deltaTime;
		time += dt;

		transform.Translate(0, -dt*currentSpeed, 0);
		currentSpeed = speed + time*accel/10;
	}
}
