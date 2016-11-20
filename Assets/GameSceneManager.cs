using UnityEngine;
using System.Collections;

public class GameSceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			GameController.Instance.GoMainMenuScene ();
		}
	}
}
