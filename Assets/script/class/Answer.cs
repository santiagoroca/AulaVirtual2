using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Answer {

	private int id;
	private string answer;

	public int _id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}

	public string _answer {
		get {
			return this.answer;
		}
		set {
			answer = value;
		}
	}

	public Answer (JSONNode data) {
		fromJson (data);
	}
	
	public Answer (int id, string answer) {
		Initialize (id, answer);
	}
	
	void Initialize (int id, string answer) {
		this._id = id;
		this._answer = answer;
	}
	
	void fromJson (JSONNode data) {
		Initialize (
			int.Parse((string) data ["id"]), 
			(string) data ["answer"]
		);
	}

}
