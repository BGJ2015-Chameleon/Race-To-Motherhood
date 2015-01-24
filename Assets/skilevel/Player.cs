using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	void Start () {
		Input.gyro.enabled = true;
		Screen.orientation = ScreenOrientation.Portrait;
	}

	float clamp(float v, float min, float max){
		if (v < min) {
				return min;
		} else if (v > max) {
			return max;
		}
		return v;
	} 

	void Update () {
		Vector3 gyro = Input.gyro.rotationRate;
		gyro.x = gyro.y;
		gyro.y = 0;
		gyro.z = 0;
		transform.Translate (gyro/10);
		Vector3 pos = transform.localPosition;
		float clamped = clamp (pos.x, -2, 2);
		pos.x = clamped;
		transform.localPosition = pos;
	}
}
