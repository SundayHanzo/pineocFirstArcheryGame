using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public int moveSpeed;
	public GameObject ruinsParticle;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
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
			GameController.Instance.AddElimLog ();
			//play sound
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
		}
		Destroy (this.gameObject);
	}
	void ShowCollisionParticle(Vector3 pos, Quaternion rot){
		GameObject particle = (GameObject)Instantiate(ruinsParticle, pos, rot);
		Destroy (particle, 1);
	}
}
