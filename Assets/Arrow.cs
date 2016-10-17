using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public int moveSpeed;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		//moveSpeed = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * moveSpeed * Time.deltaTime);
	}
}
