﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCanvasController : MonoBehaviour {
	private Text ScoreText;
	// Use this for initialization
	void Start () {
		ScoreText = this.GetComponent<Text> ();
		transform.SetParent (Camera.main.GetComponent<Transform> (), true);
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score:\n" + GameController.Instance.getScore ();
	}
}
