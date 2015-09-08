using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class SCHome : Base {

	public Text title;
	public Text description;

	public override void reload () {
		iRest.GET (Util.CLASSROOM_QUESTIONARY (getSession().classroom._id), populate);
	}

	public bool populate (string json) {
		JSONNode _json = JSON.Parse (json);
		getSession().questionary = new Questionary (_json ["result"]);
		title.text = getSession().questionary._title;
		description.text = getSession().questionary._description;
		StartCoroutine ("goToQuestions");

		return true;
	}

	IEnumerator goToQuestions() {
		yield return new WaitForSeconds(5);
		classR.setState (classR.QUESTION_STATE);
	}	

}
