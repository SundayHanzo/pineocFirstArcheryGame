using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private float score;
	private float time;
	private float power;
	private const float minPowerVal = 1.3f;
	private const float maxPowerVal = 4.1f;
	private bool isAiming = false;
	public GameObject Quad_hitmarker;
	public GameObject ScoreCanvas;
	public GameObject ElimText;

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

	void Update() {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey (KeyCode.Escape)) {
				GoMainMenuScene ();
			}
		} else {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				GoMainMenuScene ();
			}
		}
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

	//add elim log text
	public void AddElimLog(){
		GameObject log = Instantiate (ElimText);
		log.transform.SetParent (ScoreCanvas.GetComponent<Transform> (), true);
		log.transform.localScale = new Vector3 (0.5f, 0.5f, 1);
		log.transform.localPosition = new Vector3 (30.3f, -28, 10);
		log.transform.localRotation = new Quaternion ();
		Destroy (log, 0.7f);
	}
	public void capture(){
		string Screen_Shot_File_Name = "Screenshot__a" + System.DateTime.Now.ToString("__yyyy-MM-dd") + ".png";
		Application.CaptureScreenshot(Screen_Shot_File_Name);
		string Origin_Path = System.IO.Path.Combine(Application.persistentDataPath, Screen_Shot_File_Name);
		// This is the path of my folder.
		string Path = "/mnt/sdcard/DCIM/Camera/" + Screen_Shot_File_Name;
		string Path2 = "/storage/emulated/0/DCIM/" + Screen_Shot_File_Name;
		if(System.IO.File.Exists (Origin_Path))
		{
			System.IO.File.Move (Origin_Path, Path);
			System.IO.File.Copy (Origin_Path, Path2);
			print ("no original path");
		}
	}

	//Scene manager
	public void GoMainMenuScene(){
		SceneManager.LoadScene("StartScene");
	}
}
