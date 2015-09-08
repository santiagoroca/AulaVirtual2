using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SQuestion : Base {

	private float elapsedTime = 0;
	private bool start = false;

	public Text timer;
	public Text question;
	public GameObject answers_container;

	public Button buttonModel;

	public override void reload () {
		foreach (Transform child in answers_container.transform) {
			GameObject.Destroy(child.gameObject);
		}

		elapsedTime = 0;

		if (getSession().questionary._index == getSession().questionary._questions.Count) {
			WWWForm form = new WWWForm ();
			form.AddField ("data", getSession().questionary.toJson ());
			iRest.POST (Util.QUESTIONARY_COMPLETE (getSession().questionary._id), form, goToHome);
		} else {
			question.text = ((Question)getSession().questionary._questions [getSession().questionary._index])._question;
			
			foreach (Answer answer in ((Question)getSession().questionary._questions [getSession().questionary._index])._answers) {
				Button button = ((Button)Instantiate (buttonModel));
				button.GetComponentInChildren <Text> ().text = answer._answer;
				button.onClick.AddListener (() => answer_question (
					((Question)getSession().questionary._questions [getSession().questionary._index])._id, 
					answer._id,
					getSession().questionary._id
				));
				button.transform.parent = answers_container.transform;
			}

			start = true;
		}
	}

	public void answer_question (int question_id, int answer_id, int questionary_id) {
		getSession().questionary._answers.Add (new QAnswer (question_id, answer_id, questionary_id));
		getSession().questionary._index ++;

		classR.setState (classR.QUESTION_STATE);
	}

	public bool goToHome (string json) {
		Debug.Log (json);
		classR.setState (classR.MESSAGE_STATE);
		start = false;

		return true;
	}

	void Update () {
		if (start) {
			elapsedTime += Time.deltaTime;
			timer.text = (10 -  ((int)elapsedTime)) + "s";
			
			if ((10 -  ((int)elapsedTime)) == 0) {
				answer_question (((Question)getSession().questionary._questions [getSession().questionary._index])._id, 0, getSession().questionary._id);
			}
		}
	}

}
