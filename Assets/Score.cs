using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int crashes{ get; set; }
	public static int score{ get; set; }
	public static float time{ get; set; }

	private static float sTime =-1;
	private static float eTime = 0;


	public static void StartTimer(){
		sTime = Time.time;
	}

	public static void EndTimer(){
		if (sTime < 0){return;}
		eTime = Time.time;
		time += eTime - sTime;
		sTime = -1;
	}

	public static void ResetScore(){
		crashes = 0;
		score = 0;
		time = 0;
	}
}
