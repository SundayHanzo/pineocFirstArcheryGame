using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public int moveSpeed;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		//moveSpeed = 0;
		//direction = Camera.main.transform.TransformDirection(Vector3.forward);
		//direction.y = 0;

	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (direction * moveSpeed * Time.deltaTime);
	}
}
