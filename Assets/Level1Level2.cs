using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level1Level2 : MonoBehaviour {
	GameObject timeGO, hitsGO, NextButton, GoButton, image;
	public float time;
	public int hits;

	public Sprite image1, image2;

	// Use this for initialization
	void Start () {
		NextButton = GameObject.Find ("NextButton");
		GoButton = GameObject.Find ("GoButton");
		//Load Scorehandler
		timeGO = GameObject.Find ("Time");
		hitsGO = GameObject.Find ("Hits");
		image = GameObject.Find ("Image");

		GoButton.SetActive (false);

		timeGO.GetComponent <Text> ().text = "0:00:00";
		hitsGO.GetComponent <Text> ().text = "0";


	}

	// Update is called once per frame
	void Update () {
	
	}

	public void ShowLevel2(){
		image.GetComponent<Image>().sprite = image2;
		NextButton.SetActive (false);
		GoButton.SetActive (true);

	}

	public void GoToLevel2(){
		Application.LoadLevel("Level2");
	}
}
