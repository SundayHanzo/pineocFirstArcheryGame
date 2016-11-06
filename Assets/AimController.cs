using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.SetParent (Camera.main.GetComponent<Transform> (), true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
