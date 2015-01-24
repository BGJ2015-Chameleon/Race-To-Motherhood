using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		transform.Translate(0, -dt*speed, 0);
	}
}
