using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float jumpDuration;

	public float speed;
	public float accel;
	public float maxSpeed;
	public float minSpeed;

	public float reactionTime;

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

	private float timeToContraction;
	private bool birthDanger;

	void Start () {
		Input.gyro.enabled = true;
		isJumping = false;
		
		shadow = transform.Find ("Shadow");

		currentSpeed = speed;

		shadowScale = shadow.localScale;
		shadowPos = shadow.localPosition;

		redGirl = transform.Find ("RedGirl").GetChild(0).gameObject;
		bluGirl = transform.Find ("BlueGirl").GetChild(0).gameObject;

		Jump (); // for dramatic effect
		audio.PlayOneShot (sounds [1]);

		timeToContraction = Random.Range (10.0f, 25.0f);
		birthDanger = false;
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
		timeToContraction -= dt;

		if (birthDanger) {
			for(int i = 0; i < Input.touchCount; i++){
				if (Input.GetTouch(i).phase == TouchPhase.Began){
					birthDanger = false;
					transform.Find ("Warning").GetComponent<SpriteRenderer>().enabled = false;
					redGirl.GetComponent<Animator>().SetTrigger("Switch");
					bluGirl.GetComponent<Animator>().SetTrigger("Switch");
					timeToContraction = Random.Range(15.0f,30.0f);
					break;
				}
			}
			if(timeToContraction < -reactionTime){
				Application.LoadLevel("mainmenu");
				return;
			}
		}

		if (timeToContraction < 0 && !birthDanger) {
			audio.PlayOneShot(sounds[3]);
			birthDanger = true;
			transform.Find ("Warning").GetComponent<SpriteRenderer>().enabled = true;
		}

		if (Camera.main.transform.localPosition.y > -500) {
				Camera.main.transform.Translate (0, -dt * currentSpeed, 0);
		} else {
			transform.Translate(0, -dt * currentSpeed, 0);
		}
		currentSpeed += (accel/10)*dt;
		currentSpeed = clamp (currentSpeed, minSpeed, maxSpeed);


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
