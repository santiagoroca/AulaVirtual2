using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class Home : Base {

	public Button buttonModel;
	public GameObject ContentPanel;

	public override void reload () {
		foreach (Transform child in ContentPanel.transform) {
			GameObject.Destroy(child.gameObject);
		}

		iRest.GET (Util.CLASSROOM, _populate_classrooms);
	}

	private bool _populate_classrooms (string json) {
		JSONNode _json = JSON.Parse (json);

		foreach (JSONNode node in ((JSONArray)_json ["result"])) {
			Classroom cRoom = new Classroom (node);
			Button button = ((Button)Instantiate (buttonModel));
			button.GetComponentInChildren <Text> ().text = cRoom._name;
			button.onClick.AddListener (() => setClassroom (cRoom));
			button.transform.parent = ContentPanel.transform;
		}

		return true;
	}

	private void setClassroom (Classroom cRoom) {
		getSession().classroom = cRoom;

		switch (getSession ().user._type) {

		case 0: 
			uiBehaviour.setState (uiBehaviour.CLASROOM_STADISTIC_STATE);
			break;

		case 1: 
			uiBehaviour.setState (uiBehaviour.CLASSROOM_STATE);
			break;

		}
		

	}

}
