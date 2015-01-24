using UnityEngine;
using System.Collections;

public class Backround : MonoBehaviour {
	public Sprite[] tiles;
	SpriteRenderer sr;
	Transform tr;
	Camera camera;
	Vector3 scale;

	// Use this for initialization
	void Start () {

		camera = Camera.main;
		sr = GetComponent <SpriteRenderer> ();
		tr = GetComponent <Transform> ();
		sr.sprite = tiles [0];

		float cameraHeight = camera.orthographicSize * 2f;
		float cameraWidth = cameraHeight / Screen.height * Screen.width;
		scale = new Vector3 (cameraWidth / tiles[0].bounds.size.x, cameraHeight / tiles[0].bounds.size.y, 1f);
		tr.localScale = scale;

	}
	
	// Update is called once per frame
	void Update () {
		float cameraHeight = camera.orthographicSize * 2f;
		float cameraWidth = cameraHeight / Screen.height * Screen.width;
		scale = new Vector3 (cameraWidth / tiles[0].bounds.size.x, cameraHeight / tiles[0].bounds.size.y, 1f);
		tr.localScale = scale;
	}
	

}
