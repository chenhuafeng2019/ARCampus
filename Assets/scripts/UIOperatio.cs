using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOperatio : MonoBehaviour {

	// Use this for initialization
	bool isUIdisplay=true;

	Camera cm;
	void Start () {
		cm = this.gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnQuitClick(){

		Application.Quit ();
	}

	public void OnBtnhideUIClick(){
		isUIdisplay = !isUIdisplay;
		if(isUIdisplay)
			cm.cullingMask |= (1<<5);
		else
			cm.cullingMask &= ~(1<<5);
	}

	public void OpenButtonClicked() {

		var webViewGameObject = GameObject.Find("WebView");
		if (webViewGameObject == null) {
			webViewGameObject = new GameObject("WebView");
		}

		var webView = webViewGameObject.AddComponent<UniWebView>();

		// There is some useful delegate methods. You can listen to them to interact with events of UniWebView.
		// Here we want to show the web view when the loading fully completed. So we add a listener on OnLoadComplete event.
		webView.OnLoadComplete += OnLoadComplete;

		// Basicly, UniWebView is using the inset system to decide the size and positon of the web view on screen.
		// You tell UniWebView what is the inset margin from screen edges, and UniWebView will calculate the size and position.
		// You can set the insets of this webview by assigning an insets value simply if you do not want to support multiple oreitations,
		// like this:
		/*
                int bottomInset = (int)(UniWebViewHelper.screenHeight * 0.5f);
                webView.insets = new UniWebViewEdgeInsets(5,5,bottomInset,5);
        */
		// If you need support Portrait and Landspace at the same time, you need to use the `InsetsForScreenOreitation` delegate 
		// to specify different insets. Here we want it, so add the InsetsForScreenOreitation listener:
		webView.InsetsForScreenOreitation += InsetsForScreenOreitation;

		// In Android, user could always use the back button on device to close the webview. But in iOS, there is no such button.
		// There is a default tool bar with system UI-style which contains a back button for iOS for quick use in UniWebView. 
		// However, you may want to implement your own style or button for closing webview in full screen.
		webView.toolBarShow = true;

		// Now, we could set the url and load the page.
		webView.url = "http://www.jcut.edu.cn";
		webView.Load();

		// The `OnLoadComplete` will be called when the page load finished.
	}

	void OnLoadComplete(UniWebView webView, bool success, string errorMessage) {
		if (success) {
			webView.Show();
		} else {
			Debug.Log("Something wrong in webview loading: " + errorMessage);
		}
	}

	// This method will be called when the screen orientation changed. Here we return UniWebViewEdgeInsets(5,5,5,5)
	// for both situation, which means the inset is 5 point for iOS and 5 pixels for Android from all edges.
	// Note: UniWebView is using point instead of pixel in iOS. However, the `Screen.width` and `Screen.height` will give you a
	// pixel-based value. 
	// You could get a point-based screen size by using the helper methods: `UniWebViewHelper.screenHeight` and `UniWebViewHelper.screenWidth` for iOS.
	UniWebViewEdgeInsets InsetsForScreenOreitation(UniWebView webView, UniWebViewOrientation orientation) {

		if (orientation == UniWebViewOrientation.Portrait) {
			return new UniWebViewEdgeInsets(5,5,5,5);
		} else {
			return new UniWebViewEdgeInsets(5,5,5,5);
		}
	}

}
