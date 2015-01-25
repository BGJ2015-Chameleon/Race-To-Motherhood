using UnityEngine;
using System.Collections;

public class FadeOutNumber : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		SpriteRenderer r = GetComponent<SpriteRenderer> ();
		r.color = new Color (1, 1, 1, r.color.a - dt);
		if (r.color.a <= 0) {
			Destroy(gameObject);
		}
	}
}
