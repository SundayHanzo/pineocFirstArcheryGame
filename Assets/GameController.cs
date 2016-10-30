using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private float score;
	private float time;
	public Text score_text;

	private static GameController _instance = null;

	public static GameController Instance
	{
		get
		{
			if (_instance == null)
				_instance = new GameController();
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
}
