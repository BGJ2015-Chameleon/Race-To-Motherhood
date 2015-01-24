using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Backround : MonoBehaviour {
	public Transform bgprefab;
	public Transform EmptyBenchPrefab;
	public Transform SelfieGirlPrefab;

	LinkedList<Transform> bgspritelist;

	private float spriteWidth;
	private int spriteCount;

	GameObject camera;


	// Use this for initialization
	void Start () {
		camera = GameObject.FindWithTag("MainCamera");
		InitBGSprite ();
	}

	void InitBGSprite(){
		bgspritelist = new LinkedList<Transform> ();
		SpriteRenderer sprite = bgprefab.GetComponent <SpriteRenderer> ();
		spriteWidth = sprite.bounds.size.x;
		spriteCount = 0;
		for (int i = -3; i < 3; i++) {
			Transform clone = Instantiate (bgprefab) as Transform;
			clone.Translate(i*spriteWidth,0,0);
			bgspritelist.AddFirst(clone);
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBGSprite ();
	}

	void NewChunk(Transform clone) {
		

		if (Random.value > 0.001) {
			Transform EmptyBench = Instantiate (EmptyBenchPrefab) as Transform;
			EmptyBench.SetParent (clone);
			EmptyBench.transform.localPosition = new Vector3 (0, 0.4f, -2);
			//EmptyBench.GetChild((int)Mathf.Round(Random.value)).gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}

		if (Random.value > 0.001) {
			Transform SelfieGirl = Instantiate (SelfieGirlPrefab) as Transform;
			SelfieGirl.SetParent (clone);
			SelfieGirl.transform.localPosition = new Vector3 (Random.Range (-0.5f, 0.5f), Random.Range (-0.5f, 0.4f), 0);
			//EmptyBench.GetChild((int)Mathf.Round(Random.value)).gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}


		

	}

	void UpdateBGSprite(){

		float camX = ((camera.transform.position.x)/spriteWidth)+1;
		
		int newSpriteCount = (int)camX;
		if (newSpriteCount > spriteCount) {
			Transform clone = Instantiate (bgprefab) as Transform;
			clone.Translate(spriteWidth*(newSpriteCount+1),0,0);
			bgspritelist.AddFirst(clone);
			Destroy(bgspritelist.Last.Value.gameObject);
			bgspritelist.RemoveLast();
			
			NewChunk(clone);
		}
		
		spriteCount = newSpriteCount;
		
	}
	

}
