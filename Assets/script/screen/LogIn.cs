using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class LogIn : Base {

	public InputField username;
	public InputField password;

	public void log_in () {
		WWWForm form = new WWWForm ();
		form.AddField ("username", username.text);
		form.AddField ("password", password.text);

		iRest.POST (Util.AUTH, form, _log_in);
	}
	
	public override void reload () {}

	private bool _log_in (string json) {
		if (!json.Contains ("error")) {
			getSession().user = new User(JSON.Parse (json));

			if (getSession().user != null) {
				uiBehaviour.setState (uiBehaviour.HOME_STATE);
			}
		}

		return true;
	}

}
