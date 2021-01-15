using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour {

	public GameObject ball;
	private Texture2D myTexture;
	private string panoName;
	// Use this for initialization
	void Start () {
		panoName=PlayerPrefs.GetString ("PanoName", "eastGate");
		Debug.Log (panoName);
		myTexture = (Texture2D)Resources.Load(panoName);
		ball.GetComponent<MeshRenderer> ().material.mainTexture = myTexture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBtnClick(){
		SceneManager.LoadScene ("1");
	}
}
