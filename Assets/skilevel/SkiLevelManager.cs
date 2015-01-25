using UnityEngine;
using System.Collections;

public class SkiLevelManager : MonoBehaviour {
	
	public Transform player;
	public Transform goalprefab;

	public Transform[] numbers;

	public int wait;

	public Transform[] signs;

	public AudioClip[] startsfx;
	public AudioClip music;
	public AudioClip explosion;

	private float time;
	private bool started;
	private bool go;

	private int[] asOrder;

	private int oldT;

	private float startPos;

	private bool goalSpawned;

	// Use this for initialization
	void Start () {
		time = 0;
		asOrder = new int[]{0,0,0,1};
		go = false;
		started = false;
		oldT = 0;
		startPos = Camera.main.transform.localPosition.y;
		goalSpawned = false;
		
		Transform goal = Instantiate(goalprefab) as Transform;
		goal.localPosition = new Vector3(0,-505,0);
	}
	

	float cubicOutIn( float k ){
		if (k < 0.5f) {
			k *= 2;
			return (--k * k * k * k * k + 1)/2;
		}
		k = (k - 0.5f) * 2;
		return 0.5f + (k * k * k * k * k)/2;
	}

	int oldI = -1;
	Transform cSign;
	Vector3 cPos;
	Vector3 tPos = new Vector3(0,10,0);
	void Update () {
		if (started) {
			return;
		}

		if (go) {
			Transform ply = Instantiate(player) as Transform;
			ply.SetParent(Camera.main.transform);
			ply.localPosition = new Vector3(0,0,15);
			started = true;
			return;
		} 
		float t = Time.timeSinceLevelLoad;
		int intT = (int)t;
		if (intT < wait) {
			float sTime = wait/signs.Length*0.8f;
			float pTime = wait*0.1f;
			if(t > pTime){
				int index = (int)((t-pTime)/sTime);
				if(oldI < index){
					if(cSign != null){ Destroy(cSign.gameObject); }
					if( (index) < signs.Length  ){
						cSign = Instantiate(signs[index]) as Transform;
						cSign.Translate(0,5,-10);
						cPos = cSign.localPosition;
					}
					oldI = index;
				}

				if( index < signs.Length ){
					float x = cubicOutIn((t-pTime-sTime*index)/sTime );
					cSign.localPosition = cPos - tPos * x;
				}

			}
		} else if(oldT < intT){
			if(cSign != null){ Destroy(cSign.gameObject); }
			int index = intT - wait;
			go = index == 3;
			if(go){
				audio.clip = music;
				audio.loop = true;
				audio.Play();
			}
			audio.PlayOneShot(startsfx[asOrder[index]]);
			if(index < numbers.Length)
				Instantiate(numbers[index]);
			oldT = intT;

		}
	}
}
