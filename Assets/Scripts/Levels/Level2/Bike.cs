using UnityEngine;
using System.Collections;

public class Bike : MonoBehaviour {

	public float speed;
	public float accel;
	private float currentSpeed;
	GameObject alert;
	GameObject RedGirl, BlueGirl;
	Animator RedGirlAnim, BlueGirlAnim;
	public AudioClip[] sounds;

	private float timeToContraction;
	private bool birthDanger;


	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		currentSpeed = speed;
		RedGirl = GameObject.Find ("2_RedGirl");
		RedGirlAnim = RedGirl.GetComponent <Animator> ();
		BlueGirl = GameObject.Find ("2_BlueGirl");
		BlueGirlAnim = BlueGirl.GetComponent <Animator> ();

		timeToContraction = Random.Range (10.0f, 25.0f);
		birthDanger = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		timeToContraction -= dt;

		if (birthDanger) {
			for(int i = 0; i < Input.touchCount; i++){
				if (Input.GetTouch(i).phase == TouchPhase.Began){
					birthDanger = false;
					RedGirlAnim.SetTrigger("switch");
					BlueGirlAnim.SetTrigger("switch");
					timeToContraction = Random.Range(15.0f,30.0f);
					break;
				}
			}
			if(timeToContraction <= -1f){
				Application.LoadLevel("mainmenu");
				return;
			}
		}

		if (timeToContraction < 0 && !birthDanger) {
			audio.PlayOneShot(sounds[0]);
			birthDanger = true;
		}

		//camera

	
		if (Camera.main.transform.localPosition.y < 500) {
			Camera.main.transform.Translate (0, dt * currentSpeed, 0);
		} else {
			this.transform.Translate(dt * currentSpeed, 0, 0);
		}

			

		
		currentSpeed += (accel/10)*dt;

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

	public bool isInDanger(){
		return birthDanger;
	}

	void OnTriggerEnter2D(Collider2D other){
		switch (other.name) {
		case "SelfieGirl":
		case "Trashcan":
		case "Bench":
			other.enabled = false;
			currentSpeed /= 4;
			audio.PlayOneShot(sounds[1]);

			break;
		}
	}

	public void FailedQuickTimeEvent(){
		currentSpeed /= 4;
	}



	void Move(){
		Vector3 gyro = Input.gyro.rotationRate;
		gyro.x = 0;
		gyro.z = 0;
		gyro.y = -1 * gyro.y;
		transform.Translate (gyro/10);
		Vector3 pos = transform.localPosition;
		float clamped = clamp (pos.x, -3, 5);
		pos.x = clamped;
		transform.localPosition = pos;
	}
}
