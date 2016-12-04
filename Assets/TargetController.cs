using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TargetController : MonoBehaviour {
	public GameObject ruinsParticle;
	// Use this for initialization
	void Start () {
		//PositionRandomlySetting ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void PositionRandomlySetting(){
		Vector3 direction = Random.onUnitSphere;
		direction.y = Mathf.Clamp(direction.y, 1.0f, 1.5f);
		float distance = 4 * Random.value + 6.5f;
		transform.localPosition = direction * distance;
		transform.LookAt (Camera.main.transform);
	}
	void OnCollisionEnter (Collision collision) {
		//show particle
		ContactPoint contact = collision.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;

		//show particle
		ShowCollisionParticle (pos, rot);
		//targetRegen
		TargetRegen();
		//Destroy (this.gameObject);
	}
	void ShowCollisionParticle(Vector3 pos, Quaternion rot){
		GameObject particle = (GameObject)Instantiate(ruinsParticle, pos, rot);
		Destroy (particle, 1);
	}
	void TargetRegen(){
		Instantiate (this.gameObject);
	}
}
