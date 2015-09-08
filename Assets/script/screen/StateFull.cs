using UnityEngine;
using System.Collections;

public class StateFull : Base {

	public GameObject [] screen_list;
	protected Base [] script_list;
	protected int state = 0;

	public void setState (int state) {
		updateState (state);
		this.state = state;
	}
	
	private void updateState (int state) {
		screen_list [this.state].SetActive (false);
		screen_list [state].SetActive (true);
		script_list [state].reload ();
	}

	public override void reload () {
		setState (0);
	}

}
