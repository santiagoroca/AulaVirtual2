using UnityEngine;
using System.Collections;

public class QAnswer {

	private int question_id;
	private int answer_id;
	private int user_id;

	public int _question_id {
		get {
			return this.question_id;
		}
		set {
			question_id = value;
		}
	}

	public int _answer_id {
		get {
			return this.question_id;
		}
		set {
			question_id = value;
		}
	}

	public int _user_id {
		get {
			return this.question_id;
		}
		set {
			question_id = value;
		}
	}

	public QAnswer (int question_id, int answer_id, int user_id) {
		this.question_id = question_id;
		this.answer_id = answer_id;
		this.user_id = user_id;
	}

	public string toJson () {
		return "{" + 
			"\"question_id\":" + this.question_id + "," + 
			"\"answer_id\":" + this.answer_id + "," + 
			"\"user_id\":" + this.user_id + "},";
	}
	
}
