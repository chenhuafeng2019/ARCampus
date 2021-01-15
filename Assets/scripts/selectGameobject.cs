using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectGameobject : MonoBehaviour {

	Vector2 screen_pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				screen_pos = Input.touches [0].position;   
				Ray ray = Camera.main.ScreenPointToRay (new Vector3 (screen_pos.x, screen_pos.y, 0));
				RaycastHit hit;
				if (Physics.Raycast (ray,out hit)&& hit.collider.gameObject.tag!="ground"&&hit.collider.gameObject.tag!="Untagged") {
					//Destroy(hit.collider.gameObject);
					PlayerPrefs.SetString("PanoName",hit.collider.gameObject.tag);
					Debug.Log (hit.collider.gameObject.tag);
					SceneManager.LoadScene("2");
				}
			}
		}
		/*if (Input.GetMouseButton(0)) {
			Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray,out hit) && hit.collider.gameObject.tag!="ground") {
				//Destroy(hit.collider.gameObject);
				PlayerPrefs.SetString("PanoName",hit.collider.gameObject.tag);
				Debug.Log (hit.collider.gameObject.tag);
				SceneManager.LoadScene("2");
			}
		}*/
	}
}
