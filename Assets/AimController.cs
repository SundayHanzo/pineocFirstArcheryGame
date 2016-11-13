using UnityEngine;
using System.Collections;

public class AimController : MonoBehaviour {
	private GameObject aimCircle;
	// Use this for initialization
	void Start () {
		transform.SetParent (Camera.main.GetComponent<Transform> (), true);
		aimCircle = (GameObject)this.gameObject.transform.GetChild (3).gameObject;
		//print (aimCircle.name);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCircleSprite ();
	}
	private void UpdateCircleSprite(){
		float circleRatio = GameController.Instance.getAimCirclePercent ();
		aimCircle.transform.localScale = new Vector3 (circleRatio, circleRatio, 1.0f);
	}
}
