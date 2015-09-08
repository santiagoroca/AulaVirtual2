using UnityEngine;
using System.Collections;
using System;
using SimpleJSON;

public class REST : MonoBehaviour {

	public bool isBusy = false;

	public void GET(string uri, Func <string, bool> callback) {
		if (!isBusy)
		 	StartCoroutine (doGet(uri, callback));
	}

	public void POST(string uri, WWWForm form, Func <string, bool> callback) {
		if (!isBusy)
			StartCoroutine (doPost(uri, form, callback));
	}

	IEnumerator doGet(string uri, Func <string, bool> callback){
		isBusy = true;
		WWW w = new WWW(Util.BASE + uri);
		yield return w;
		isBusy = false;
		callback(w.text);
	}

	IEnumerator doPost(string uri, WWWForm form, Func <string, bool> callback){
		isBusy = true;
		WWW w = new WWW(Util.BASE + uri, form);
		yield return w;
		isBusy = false;
		callback (w.text);
	}

}
