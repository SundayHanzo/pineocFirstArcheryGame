using UnityEngine;
using System.Collections;

public class ArrowFire : MonoBehaviour {
	public GameObject Quad_arrow = null;
	public Transform ArrowLocation = null;
	private float powerVal = 2.1f;
	private const float minPowerVal = 1.0f;
	private const float maxPowerVal = 4.1f;
	private const float fireRate = 0.5f;
	private const float fireYVal = 0.045f;
	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
		//Object.Destroy (Quad_arrow, 10f);

	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.touchCount > 0) || Input.GetKey (KeyCode.Space) == true) {
			//touch down started
			if(powerVal < maxPowerVal && Time.time > nextFire)
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
				t.y += fireYVal;
				arrowObj.GetComponent<Rigidbody> ().AddForce (t * 500 * powerVal);
				powerVal = minPowerVal;
			}
		}
	}
}
