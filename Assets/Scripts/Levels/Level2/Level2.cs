using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level2 : MonoBehaviour {

	GameObject Background1, Background2, Background3, Background4;
	Camera camera;
	float velocity, CameraHeight, CameraWidth, BackgroundY;


	// Use this for initialization
	void Start () {
		Background1 = GameObject.Find ("Background1");
		Background2 = GameObject.Find ("Background2");
		Background3 = GameObject.Find ("Background3");
		Background4 = GameObject.Find ("Background4");
		CameraHeight = Camera.main.orthographicSize;
		CameraWidth = CameraHeight * Camera.main.aspect;
		BackgroundY = Background1.transform.position.y;

		velocity = 0.2f;
		Background1.transform.position = new Vector3 (-CameraWidth, BackgroundY);
	}
	
	// Update is called once per frame
	void Update () {
		Background1.transform.position = new Vector3 (Background1.transform.position.x - velocity, BackgroundY);
		Background2.transform.position = new Vector3 (Background1.transform.position.x + Background1.transform.localScale.x, BackgroundY);
		Background3.transform.position = new Vector3 (Background2.transform.position.x + Background2.transform.localScale.x, BackgroundY);
		Background4.transform.position = new Vector3 (Background3.transform.position.x + Background3.transform.localScale.x, BackgroundY);

		if(Background2.transform.position.x < (0 - (CameraWidth))){
			Background1.transform.position = new Vector3 (-CameraWidth, BackgroundY);
			Background2.transform.position = new Vector3 (Background1.transform.position.x + Background1.transform.localScale.x, BackgroundY);
			Background3.transform.position = new Vector3 (Background2.transform.position.x + Background2.transform.localScale.x, BackgroundY);
			Background4.transform.position = new Vector3 (Background3.transform.position.x + Background3.transform.localScale.x, BackgroundY);

		}





	
	}






}
