using UnityEngine;
using System.Collections;

public class SCMessage : Base {

	public override void reload () {
		StartCoroutine ("goToHome");
	}
	
	IEnumerator goToHome() {
		yield return new WaitForSeconds(3);
		uiBehaviour.setState (uiBehaviour.HOME_STATE);
	}	

}
