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
			string str = "";
			if (collision.collider.name.Contains ("100")) {
				str = "100";
			} else if (collision.collider.name.Contains ("80")) {
				str = "80";
			} else if (collision.collider.name.Contains ("50")) {
				str = "50";
			} else if (collision.collider.name.Contains ("30")) {
				str = "30";
			} else if (collision.collider.name.Contains ("10")) {
				str = "10";
			} else {
				str = "0";
			}
			checkTargetAndScore (str);
			scored = true;
		}
		Destroy (this.gameObject.GetComponent<Rigidbody>());
		Destroy (this.gameObject.GetComponent<BoxCollider>());
	}
	//show collision particle on collide position
	void ShowCollisionParticle(Vector3 pos, Quaternion rot){
		GameObject particle = (GameObject)Instantiate(ruinsParticle, pos, rot);
		Destroy (particle, 1);
	}
	void checkTargetAndScore(string name){
		if (scored == false) {
			//print ("scored, " + name);
			if (name.Equals ("100")) {
				GameController.Instance.AddElimLog ("100");
				GameController.Instance.addScore (100);
			} else if (name.Equals ("80")) {
				GameController.Instance.AddElimLog ("80");
				GameController.Instance.addScore (80);
			} else if (name.Equals ("50")) {
				GameController.Instance.AddElimLog ("50");
				GameController.Instance.addScore (50);
			} else if (name.Equals ("30")) {
				GameController.Instance.AddElimLog ("30");
				GameController.Instance.addScore (30);
			} else if (name.Equals ("10")) {
				GameController.Instance.AddElimLog ("10");
				GameController.Instance.addScore (10);
			} else {
				//GameController.Instance.AddElimLog ("0");
				//GameController.Instance.addScore (0);
			}
		}
	}
}
