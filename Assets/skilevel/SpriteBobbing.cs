using UnityEngine;
using System.Collections;

public class SpriteBobbing : MonoBehaviour {

	public float tOffset;
	public float ms;
	public float amount;

	private float time;
	private Vector3 pos;

	void Start() {
		time = tOffset;
		pos = transform.localPosition;
	}

	float old = 0;

	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		time += dt;

		float bob = (int)(time/ms)%2;
		print (bob);

		if (old != bob){
			transform.localPosition = pos + new Vector3(0,amount*bob,0);
			old = bob;
		}
	}
}
