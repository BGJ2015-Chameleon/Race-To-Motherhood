using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSetTime : MonoBehaviour {
	
	public Text hits;

	private int ms;
	private int s;
	private int m;

	// Use this for initialization
	void Start () {
		m = (int)(Score.time / 60);
		s = (int)(Score.time - m * 60);
		ms = (int)((Score.time - (int)Score.time)*100);
		print (m);
		print (m);
		print (ms);
	}
	
	// Update is called once per frame
	void Update () {

		hits.text = m.ToString() + ":" + (s > 10 ? s.ToString() : "0" + s.ToString() ) + 
			":" + (ms > 10 ? ms.ToString() : "0" + ms.ToString() );
		
	}
}
