using UnityEngine;
using System.Collections;

public class logo_GlobalGameJam : MonoBehaviour {

	public Sprite[] sprites;
	float alpha;
	int isVisible, fadeIn, fadeOut, fadeDuration, nextSprite;
	SpriteRenderer logo;
	// Use this for initialization
	void Start () {

		logo = this.GetComponent<SpriteRenderer>();
		isVisible = 0;
		fadeIn = 1;
		fadeDuration = 1;
		alpha = 0f;
		nextSprite = 0;
	}
	
	// Update is called once per frame
	void Update () {
			if(isVisible == 0){
				//Fade in
				if(fadeIn == 1){
					if(alpha < 1f){
						alpha = alpha + (Time.deltaTime / fadeDuration);
						logo.color = new Color(1f, 1f, 1f, alpha);
					}
					if(alpha >= 1f){
						isVisible = 1;
						fadeIn = 0;
						fadeOut = 1;
					}
				}
			}
			if(isVisible == 1){
				if(fadeOut == 1){
					if(alpha > 0f){
						alpha = alpha - (Time.deltaTime / fadeDuration);
						logo.color = new Color(1f, 1f, 1f, alpha);
					}
					if(alpha <= 0f){
						isVisible = 0;
						fadeOut = 0;
						
						
						if(nextSprite >= sprites.Length ){
						Debug.Log("Intro finished. Loading menu");
						Application.LoadLevel("menuToSki");
						}
						else {
						logo.sprite = sprites[nextSprite];
						nextSprite++;
						fadeIn = 1;
						}

						
					}
				}
			}
		
		//wait
		//fade out
		//call next
	}



}
