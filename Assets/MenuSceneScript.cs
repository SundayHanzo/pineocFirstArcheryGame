using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuSceneScript : MonoBehaviour {
	private GameObject PopupCanvas;
	// Use this for initialization
	void Start () {
		PopupCanvas = GameObject.Find ("/Canvas/PopupCanvas");
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKey(KeyCode.Escape))
			{
				if (PopupCanvas.GetComponent<Canvas> ().enabled)
					HidePopup ();
				else {
					Application.Quit();
				}
			}
		}
	}
	public void ShowPopup(){
		PopupCanvas.GetComponent<Canvas> ().enabled = true;
	}
	public void HidePopup(){
		PopupCanvas.GetComponent<Canvas> ().enabled = false;
	}
	public void GotoNormalGameScene(){
		SceneManager.LoadScene ("GameScene_normal");
	}
	public void GotoVRGameScene(){
		SceneManager.LoadScene ("GameScene_vr");
	}
}
