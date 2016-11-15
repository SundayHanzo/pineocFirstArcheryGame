using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private float score;
	private float time;
	private float power;
	private const float minPowerVal = 1.3f;
	private const float maxPowerVal = 4.1f;
	private bool isAiming = false;
	public GameObject Quad_hitmarker;

	private static GameController _instance = null;

	public static GameController Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError ("gamecontroller null");
			return _instance;
		}
	}

	// Use this for initialization
	void Start () {

	}

	void Awake () {
		_instance = this;
	}

	//score get,set
	public void setScore (float s) {
		score = s;
	}
	public float getScore () {
		return score;
	}
	public void addScore (float s) {
		score += s;
	}

	//time get, set
	public void setTime (float t) {
		time = t;
	}
	public float getTime () {
		return time;
	}

	//power get,set
	public void setPower (float p){
		power = p;
	}
	public float getPower () {
		return power;
	}
	public float getMinPowerVal(){
		return minPowerVal;
	}
	public float getMaxPowerVal(){
		return maxPowerVal;
	}
	public float getAimCirclePercent(){
		if (isAiming) {
			if (power == minPowerVal) {
				return 0.8f;
			} else if (power > minPowerVal && power < maxPowerVal) {
				return (maxPowerVal - power) / maxPowerVal;
			} else {
				return 0.05f;
			}
		} else {
			return 0.0f;
		}
	}
	public void setIsAiming(bool b) {
		isAiming = b;
	}
	public bool getIsAiming() {
		return isAiming;
	}
	public void showHitMarker(){
		//GameObject oHitMarker = (GameObject)Instantiate(Quad_hitmarker, new Vector3 (-0.01f, 0, 0), Quaternion.identity);
		//oHitMarker.transform.SetParent(Camera.main.GetComponent<Transform> ().GetChild(3), true);
		//oHitMarker.transform.position = new Vector3 (-0.01f, 0, 0);
		Quad_hitmarker.GetComponent<SpriteRenderer>().enabled = true;
		print (Quad_hitmarker.transform.position);
		StartCoroutine (hideHitMarker(0.05f));
	}
	private IEnumerator hideHitMarker(float time)
	{
		yield return new WaitForSeconds(time);
		// Code to execute after the delay
		Quad_hitmarker.GetComponent<SpriteRenderer>().enabled=false;
	}
}
