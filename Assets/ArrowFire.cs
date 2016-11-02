using UnityEngine;
using System.Collections;

public class ArrowFire : MonoBehaviour {
	public GameObject Quad_arrow = null;
	public Transform ArrowLocation = null;
	private float powerVal = 2.0f;
	private const float fireRate = 0.5f;
	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
		//Object.Destroy (Quad_arrow, 10f);

	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.touchCount > 0) || Input.GetKey (KeyCode.Space) == true) {
			//touch down started
			if(powerVal < 6.0f && Time.time > nextFire)
				powerVal += 0.1f;
		}
		if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || 
			Input.GetKeyUp(KeyCode.Space) == true) {
			//touch up ended
			//arrow object set, addforce
			if(Time.time > nextFire){
				nextFire = Time.time + fireRate;
				GameObject arrowObj = Instantiate (Quad_arrow, ArrowLocation.position, ArrowLocation.rotation) as GameObject;
				Vector3 t = Camera.main.transform.forward;
				t.y += 0.05f;
				arrowObj.GetComponent<Rigidbody> ().AddForce (t * 500 * powerVal);
				powerVal = 2.0f;
			}
		}
	}
}
