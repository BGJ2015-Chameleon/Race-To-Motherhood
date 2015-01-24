using UnityEngine;
using System.Collections;

public class SkiLevelManager : MonoBehaviour {
	
	public Transform player;

	public int wait;
	public AudioClip[] startsfx;
	public AudioClip music;
	public AudioClip explosion;

	private float time;
	private bool started;
	private bool go;

	private int[] asOrder;

	private int oldT;

	// Use this for initialization
	void Start () {
		time = 0;
		asOrder = new int[]{0,0,0,1};
		go = false;
		started = false;
		oldT = 0;
	}

	void Update () {
		if (started) {
			return;
		}

		if (go) {
			Transform ply = Instantiate(player) as Transform;
			ply.SetParent(Camera.main.transform);
			ply.localPosition = new Vector3(0,0,5);
			started = true;
			return;
		} 

		int intT = (int)Time.timeSinceLevelLoad;
		if (intT < wait) {

		} else if(oldT < intT){
			int index = intT - wait;
			go = index == 3;
			if(go){
				audio.clip = music;
				audio.loop = true;
				audio.Play();
			}
			audio.PlayOneShot(startsfx[asOrder[index]]);
			oldT = intT;

		}
	}
}
