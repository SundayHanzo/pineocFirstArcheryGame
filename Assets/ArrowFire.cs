using UnityEngine;
using System.Collections;

public class ArrowFire : MonoBehaviour {
	public GameObject Quad_arrow = null;
	public Transform ArrowLocation = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 || Input.GetKeyUp(KeyCode.Space) == true) {
			print ("Arrow Fire!");
			Instantiate (Quad_arrow, ArrowLocation.position, ArrowLocation.rotation);
		}
	}
}
