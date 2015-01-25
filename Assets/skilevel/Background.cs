using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {
	public Transform bgprefab;
	public Sprite bgsprite;

	public Transform jumpprefab;
	public Transform bushprefab;
	public Transform treeprefab;
	public Transform cottageprefab;

	private GameObject camera;
	private float spriteHeight;
	private int spriteCount;

	LinkedList<Transform> bgspritelist;

	// Use this for initialization
	void Start () {
		InitBGSprite ();
	}

	void InitBGSprite(){
		bgspritelist = new LinkedList<Transform> ();
		spriteCount = 0;
		camera = GameObject.FindWithTag("MainCamera");
		spriteHeight = -bgsprite.bounds.size.y * 2.5f;

		for (int i = -1; i < 2; i++) {
			Transform clone = Instantiate (bgprefab) as Transform;
			clone.Translate(0,i*spriteHeight,0);
			bgspritelist.AddFirst(clone);
		}

		Transform cottage = Instantiate (cottageprefab) as Transform;

		cottage.SetParent (bgspritelist.First.Next.Value);
		cottage.localPosition = new Vector3 (0,0,-11);
	}


	// Update is called once per frame
	void Update () {
		UpdateBGSprite ();
	}

	// Add other objects here
	void NewChunk(Transform clone) {

		if (Random.value > 0.8) {
				Transform jump = Instantiate (jumpprefab) as Transform;
				jump.SetParent (clone);
				jump.transform.localPosition = new Vector3 (Random.Range (-1.0f, 1.0f), 0, -1);
		}

		
		if (Random.value > 0.8) {
			Transform tree = Instantiate (treeprefab) as Transform;
			tree.SetParent (clone);
			tree.transform.localPosition = new Vector3 (Random.Range (-1.0f, 1.0f), 0, -1);
			tree.GetChild((int)Mathf.Round(Random.value)).gameObject.GetComponent<SpriteRenderer>().enabled = true;

		}
		
		for(int i = 0; i < 5; i++){
			if (Random.value > 0.8) {
				Transform bush = Instantiate (bushprefab) as Transform;
				bush.SetParent (clone);
				bush.transform.localPosition = new Vector3 (Random.Range (-1.0f, 1.0f), Random.Range (0.0f, -2.0f), -1);
			}
		}
	}

	void UpdateBGSprite(){
		float camY = ((camera.transform.position.y + 2.5f)/spriteHeight)+1;
		
		int newSpriteCount = (int)camY;
		if (newSpriteCount > spriteCount) {
			Transform clone = Instantiate (bgprefab) as Transform;
			clone.Translate(0,spriteHeight*(newSpriteCount+1),0);
			bgspritelist.AddFirst(clone);
			Destroy(bgspritelist.Last.Value.gameObject);
			bgspritelist.RemoveLast();

			NewChunk(clone);
		}
		
		spriteCount = newSpriteCount;
	}

}
