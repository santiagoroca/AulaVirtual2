using UnityEngine;
using System.Collections;

public class UIBehaviour : StateFull {

	public int LOG_IN_STATE = 0;
	public int HOME_STATE = 1;
	public int CLASSROOM_STATE = 2;
	public int CLASROOM_STADISTIC_STATE = 3;

	void Start () {
		script_list = new Base[4];
		script_list [0] = transform.GetComponent <LogIn> ();
		script_list [1] = transform.GetComponent <Home> ();
		script_list [2] = transform.GetComponent <SClassroom> ();
		script_list [3] = transform.GetComponent <ClasroomStadistic> ();
	}

}
