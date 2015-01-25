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


		for (int i = 0; i < slides.Length; i++) {
			clones[i] = Instantiate(slides[i]) as Transform;
		}
		float spriteWidth = clones [0].GetComponent<SpriteRenderer> ().bounds.size.x;
		spriteOffset = new Vector3 (spriteWidth, 0, 0);
		for (int i = 0; i < clones.Length; i++){
			clones[i].localPosition = spriteOffset * i;
		}

		wait = timePerSlide [0];
		c = 0;
	}


	void Update () {
		float t = Time.time;

		if (wait < t) {
			c++;
			if(c >= clones.Length){
				Application.LoadLevel("skilevel");
				return;
			}
			for(int i = 0; i < clones.Length; i++){
				clones[i].localPosition = spriteOffset * (i-c);
			}
			wait += timePerSlide[c];
		}
	}
}
