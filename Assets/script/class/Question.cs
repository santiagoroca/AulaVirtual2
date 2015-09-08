using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class Question {

	private int id;
	private string question;
	private int correct;
	private List <Answer> answers;

	public int _id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}

	public string _question {
		get {
			return this.question;
		}
		set {
			question = value;
		}
	}

	public int _correct {
		get {
			return this.correct;
		}
		set {
			correct = value;
		}
	}

	public List<Answer> _answers {
		get {
			return this.answers;
		}
		set {
			answers = value;
		}
	}

	public Question (JSONNode data) {
		fromJson (data);
	}

	void Initialize (int id, string question, int correct, JSONArray answers) {
		this._id = id;
		this._question = question;
		this._correct = correct;

		this._answers = new List <Answer> ();
		foreach (JSONNode answer in answers) {
			this._answers.Add (new Answer(answer));
		}
	}
	
	void fromJson (JSONNode data) {
		Initialize (
			int.Parse((string) data ["id"]), 
			(string) data ["question"], 
			int.Parse((string) data ["correct_answer_id"]), 
			(JSONArray) data["answers"]
		);
	}

}
