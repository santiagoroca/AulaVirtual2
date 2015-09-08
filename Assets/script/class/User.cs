using UnityEngine;
using System.Collections;
using SimpleJSON;

public class User {

	private int id;
	private string user;
	private int type;

	public int _id {
		get {
			return this.id;
		}
		set {
			id = value;
		}
	}
	
	public string _user {
		get {
			return this.user;
		}
		set {
			user = value;
		}
	}
	
	public int _type {
		get {
			return this.type;
		}
		set {
			type = value;
		}
	}

	public User (JSONNode data) {
		fromJson (data);
	}

	public User (int id, string user, int type) {
		Initialize (id, user, type);
	}

	void Initialize (int id, string user, int type) {
		this._id = id;
		this._user = user;
		this._type = type;
	}

	void fromJson (JSONNode _data) {
		Initialize (
			int.Parse((string) _data ["result"]["id"]),
			(string) _data ["result"]["username"],
			int.Parse((string) _data ["result"]["role"])
		);
	}

}
