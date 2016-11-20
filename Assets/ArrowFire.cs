using UnityEngine;
using System.Collections;

public class ArrowFire : MonoBehaviour {
	public GameObject Quad_arrow = null;
	public Transform ArrowLocation = null;
	private float powerVal = 1.0f;
	private const float minPowerVal = 1.3f;
	private const float maxPowerVal = 4.1f;
	private const float fireRate = 0.5f;
	private const float fireYVal = 0.045f;
	private float nextFire = 0.0f;
	private GameObject showArrow;
	private Vector3 showArrowInitPos;

	// Use this for initialization
	void Start () {
		//Object.Destroy (Quad_arrow, 10f);
		showArrow = Camera.main.transform.GetChild(1).gameObject;
		showArrowInitPos = showArrow.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.touchCount > 0) || Input.GetKey (KeyCode.Space) == true) {
			//touch down started
			if(powerVal < maxPowerVal && Time.time > nextFire)
				powerVal += 0.1f;
			GameController.Instance.setPower (powerVal); //set power on gameController
			GameController.Instance.setIsAiming (true); //set isAiming true
			//set Arrow to back
			if(showArrow.transform.localPosition.z > 2.4f)
				showArrow.transform.Translate(Vector3.up * 0.028f);
		}
		if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) || 
			Input.GetKeyUp(KeyCode.Space) == true) {
			//touch up ended
			//arrow object set, addforce
			if(Time.time > nextFire){
				showArrow.transform.localPosition = showArrowInitPos;
				nextFire = Time.time + fireRate;
				GameObject arrowObj = Instantiate (Quad_arrow, ArrowLocation.position, ArrowLocation.rotation) as GameObject;
				Vector3 t = Camera.main.transform.forward;
				t.y += fireYVal;
				arrowObj.GetComponent<Rigidbody> ().AddForce (t * 500 * powerVal);
				//reset power value
				powerVal = minPowerVal;
				GameController.Instance.setPower (powerVal); //set power on gameController
			}
			GameController.Instance.setIsAiming (false); //set isAiming false
		}
	}
}
