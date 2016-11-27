using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public int moveSpeed;
	public GameObject ruinsParticle;
	private Vector3 direction;
	private bool scored;

	// Use this for initialization
	void Start () {
		scored = false;
		Destroy (this.gameObject, 10);
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
			//show particle
			ContactPoint contact = collision.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			//show particle
			ShowCollisionParticle (pos, rot);
		} else if (collision.collider.gameObject.tag == "target") {
			//some action here
			//Show hit marker
			GameController.Instance.showHitMarker();
			if (collision.collider.name.Contains ("100")) {
				GameController.Instance.AddElimLog ("100");
			} else if (collision.collider.name.Contains ("80")) {
				GameController.Instance.AddElimLog ("80");
			} else if (collision.collider.name.Contains ("50")) {
				GameController.Instance.AddElimLog ("50");
			} else if (collision.collider.name.Contains ("30")) {
				GameController.Instance.AddElimLog ("30");
			} else if (collision.collider.name.Contains ("10")) {
				GameController.Instance.AddElimLog ("10");
			}
			checkTargetAndScore (collision.collider.name);
			scored = true;
			//play sound
			AudioSource[] audio = GetComponents<AudioSource>();
			audio[0].Play();
		}
		Destroy (this.gameObject);
	}
	void ShowCollisionParticle(Vector3 pos, Quaternion rot){
		GameObject particle = (GameObject)Instantiate(ruinsParticle, pos, rot);
		Destroy (particle, 1);
	}
	void checkTargetAndScore(string name){
		if (scored == false) {
			if (name.Contains ("100")) {
				GameController.Instance.addScore (100);
			} else if (name.Contains ("80")) {
				GameController.Instance.addScore (80);
			} else if (name.Contains ("50")) {
				GameController.Instance.addScore (50);
			} else if (name.Contains ("30")) {
				GameController.Instance.addScore (30);
			} else if (name.Contains ("10")) {
				GameController.Instance.addScore (10);
			}
		}
	}
}
