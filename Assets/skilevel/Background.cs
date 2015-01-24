using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Background : MonoBehaviour {
	public Transform bgprefab;
	public Sprite bgsprite;
	private GameObject camera;
	public float spriteHeight;
	private int spriteCount;

	LinkedList<Transform> bgspritelist;

	// Use this for initialization
	void Start () {
		bgspritelist = new LinkedList<Transform> ();
		spriteCount = 0;
		camera = GameObject.FindWithTag("MainCamera");
		spriteHeight = -bgsprite.bounds.size.y * 2.5f;

		bgspritelist.AddFirst( Instantiate (bgprefab) as Transform);
		bgspritelist.First.Value.Translate(0,-spriteHeight,0);
		bgspritelist.AddFirst( Instantiate (bgprefab) as Transform);
		bgspritelist.AddFirst( Instantiate (bgprefab) as Transform);
		bgspritelist.First.Value.Translate(0,spriteHeight,0);
	}


	// Update is called once per frame
	void Update () {
		float camY = ((camera.transform.position.y + 2.5f)/spriteHeight)+1;

		int newSpriteCount = (int)camY;
		if (newSpriteCount > spriteCount) {
			Transform clone = Instantiate (bgprefab) as Transform;
			clone.Translate(0,spriteHeight*(newSpriteCount+1),0);
			bgspritelist.AddFirst(clone);
			Destroy(bgspritelist.Last.Value.gameObject);
			bgspritelist.RemoveLast();
		}

		spriteCount = newSpriteCount;

	}
}
