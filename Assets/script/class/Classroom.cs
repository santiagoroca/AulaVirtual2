using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.Collections.Generic;

public class Classroom {

	private int id;
	private string name;
	private List <Question> questions;

	public int _id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}

	public string _name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}

	public List<Question> _questions {
		get {
			return this.questions;
		}
		set {
			questions = value;
		}
	}

	public Classroom (JSONNode data) {
		fromJson (data);
	}
	
	public Classroom (int id, string name) {
		Initialize (id, name);
	}
	
	void Initialize (int id, string name) {
		this._id = id;
		this._name = name;
		this._questions = new List<Question> ();
	}
	
	void fromJson (JSONNode data) {
		Initialize (int.Parse((string) data ["id"]), (string) data ["name"]);
	}

}
