using UnityEngine;
using System.Collections;

public class SkiDoor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		GetComponent<Animator>().SetTrigger("Break");
	}
}
