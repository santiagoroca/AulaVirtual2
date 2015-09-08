using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Questionary : MonoBehaviour {

	private int id;
	private int aula_id;
	private string title;
	private string description;
	private ArrayList questions;
	private ArrayList answers;

	private int questionIndex = 0;
	
	public int _id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}
	
	public int _aula_id {
		get {
			return this.aula_id;
		}
		set {
			aula_id = value;
		}
	}
	
	public string _title {
		get {
			return this.title;
		}
		set {
			title = value;
		}
	}
	
	public string _description {
		get {
			return this.description;
		}
		set {
			description = value;
		}
	}

	public int _index {
		get {
			return this.questionIndex;
		}
		set {
			questionIndex = value;
		}
	}

	public ArrayList _questions {
		get {
			return this.questions;
		}
	}

	public ArrayList _answers {
		get {
			return this.answers;
		}
	}
	
	public Questionary (JSONNode data) {
		fromJson (data);
	}
	
	void Initialize (int id, int aula_id, string title, string description, JSONArray questions) {
		this._id = id;
		this._aula_id = aula_id;
		this._title = title;
		this._description = description;

		this.answers = new ArrayList ();
		this.questions = new ArrayList ();
		foreach (JSONNode question in questions) {
			this._questions.Add (new Question (question));
		}
	}
	
	void fromJson (JSONNode data) {
		Initialize (
			int.Parse((string) data ["id"]), 
			int.Parse((string) data ["aula_id"]), 
			(string) data ["title"], 
			(string) data ["desc"],
			(JSONArray) data ["questions"]
		);
	}

	public string toJson () {
		string json = "{\"answers\":[";

		foreach (QAnswer qAnswer in answers) {
			json += qAnswer.toJson ();
		}

		json = json.Substring (0, json.Length - 1);
		json += "]}";

		return json;
	}

}
