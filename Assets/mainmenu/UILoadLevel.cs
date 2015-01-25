using UnityEngine;
using System.Collections;

public class UILoadLevel : MonoBehaviour {
	public string level;

	public void LoadLevel(){
		Application.LoadLevel(level);
	}
}
