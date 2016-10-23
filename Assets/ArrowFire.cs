using UnityEngine;
using System.Collections;

public class ArrowFire : MonoBehaviour {
	public GameObject Quad_arrow = null;
	public Transform ArrowLocation = null;

	// Use this for initialization
	void Start () {
		//Object.Destroy (Quad_arrow, 10f);

	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || 
			Input.GetKeyUp(KeyCode.Space) == true) {
			Vector3 ArrowFirePos = Camera.main.ScreenToWorldPoint (new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane));

			//arrow object set, addforce
			GameObject arrowObj = Instantiate (Quad_arrow, ArrowLocation.position, ArrowLocation.rotation) as GameObject;
			arrowObj.GetComponent<Rigidbody> ().AddForce (Camera.main.transform.forward * 500);
		}
	}
}
