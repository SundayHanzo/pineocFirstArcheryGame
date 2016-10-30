using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public int moveSpeed;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (direction * moveSpeed * Time.deltaTime);
	}

	//isCollideTrigger
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.tag == "box") {
			//print ("crushed!");
			Destroy (GetComponent<Rigidbody> ());
			Destroy (this.gameObject, 7);
		} else if (collision.collider.gameObject.tag == "target") {
			Destroy (this.gameObject);
		}
	}
}
