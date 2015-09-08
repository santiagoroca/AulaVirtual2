using UnityEngine;
using System.Collections;

public class SClassroom : StateFull {

	public int HOME_STATE = 0;
	public int QUESTION_STATE = 1;
	public int MESSAGE_STATE = 2;

	void Start () {
		script_list = new Base[3];
		script_list [0] = transform.GetComponent <SCHome> ();
		script_list [1] = transform.GetComponent <SQuestion> ();
		script_list [2] = transform.GetComponent <SCMessage> ();
	}

}
