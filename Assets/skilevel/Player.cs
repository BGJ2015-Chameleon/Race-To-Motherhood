using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpDuration;

	public float speed;
	public float accel;


	public AudioClip[] sounds;

	private GameObject redGirl;
	private GameObject bluGirl;

	private float currentSpeed;

	private bool isJumping;
	private float tJumpLeft;
	private GameObject camera;
	private Transform shadow;

	private Vector3 shadowScale;
	private Vector3 shadowPos;


	void Start () {
		Input.gyro.enabled = true;
		isJumping = false;
		
		shadow = transform.Find ("Shadow");

		currentSpeed = speed;

		shadowScale = shadow.localScale;
		shadowPos = shadow.localPosition;

		redGirl = transform.Find ("RedGirl").gameObject;
		bluGirl = transform.Find ("BlueGirl").gameObject;

		Jump (); // for dramatic effect
		audio.PlayOneShot (sounds [1]);
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

		Camera.main.transform.Translate(0, -dt*currentSpeed, 0);
		currentSpeed += (accel/10)*dt;

		if (Input.GetKeyDown (KeyCode.Space)) {
			redGirl.GetComponent<Animator>().SetTrigger("Switch");
			bluGirl.GetComponent<Animator>().SetTrigger("Switch");
		}

		if (!isJumping) {
			Move ();
		} else {
			tJumpLeft -= dt;
			float jumpProg = (tJumpLeft/jumpDuration);
			float sOffset = Mathf.Abs (jumpProg*2-1)-1;
			shadow.localPosition = shadowPos + new Vector3(0,sOffset/6,0);
			shadow.localScale = shadowScale/(-sOffset/3+1);
			isJumping = tJumpLeft > 0;

			if(!isJumping){
				transform.Find ("TrailLeft").GetComponent<TrailRenderer> ().enabled = true;
				transform.Find ("TrailRight").GetComponent<TrailRenderer> ().enabled = true;
				rigidbody2D.WakeUp();
				audio.PlayOneShot(sounds[2]);

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
					audio.PlayOneShot (sounds [1]);
				}
				break;
			case "Tree":
				audio.PlayOneShot (sounds [1]);
				currentSpeed /= 4;
				break;
		}
	}

	void Jump(){
		audio.PlayOneShot( sounds [0] );
		isJumping = true;
		tJumpLeft = jumpDuration;
		transform.Find ("TrailLeft").GetComponent<TrailRenderer> ().enabled = false;
		transform.Find ("TrailRight").GetComponent<TrailRenderer> ().enabled = false;
	}
}
