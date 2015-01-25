using UnityEngine;
using System.Collections;

public class MenuToSki : MonoBehaviour {

	public Transform[] slides;
	public float[] timePerSlide;

	public Transform[] clones;

	private Vector3 spriteOffset;
	private float wait;
	private int c;
	void Start () {
		clones = new Transform[4];
		float height = Camera.main.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;

		for (int i = 0; i < slides.Length; i++) {
			clones[i] = Instantiate(slides[i]) as Transform;
			clones[i].localScale = new Vector3(width/4, height/5, 0.1f);
		}
		float spriteWidth = clones [0].GetComponent<SpriteRenderer> ().bounds.size.x;
		spriteOffset = new Vector3 (spriteWidth, -height/2, 0);
		for (int i = 0; i < clones.Length; i++){
			clones[i].localPosition = spriteOffset * i;
		}

		wait = timePerSlide [0];
		c = 0;
	}


	void Update () {
		float t = Time.timeSinceLevelLoad;

		if (wait < t) {
			c++;
			if(c >= clones.Length){
				Application.LoadLevel("mainmenu");
				return;
			}
			for(int i = 0; i < clones.Length; i++){
				clones[i].localPosition = spriteOffset * (i-c);
			}
			wait += timePerSlide[c];
		}
	}
}
