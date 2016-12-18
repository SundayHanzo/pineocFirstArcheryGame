using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public JoystickController joystick;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float speed = 4.0f;
		float xRot = speed * joystick.Vertical();
		float yRot = speed * joystick.Horizontal();
		print (transform.rotation);
		//if(transform.rotation.x >= -0.7f && transform.rotation.x <= 0.1f)
			transform.Rotate(xRot, yRot, 0.0f);
	}
}
