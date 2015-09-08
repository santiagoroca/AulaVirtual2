using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

	public static string DOMAIN = "localhost";

	public static string BASE = "http://" + DOMAIN  +"/calixto/";

	public static string AUTH = "auth/";
	public static string CLASSROOM = "classroom/";
	public static string USER = "user/";
	public static string STADISTIC = "stadistics/";

	public static string QUESTIONARY = "questionary/";
	public static string COMPLETE = "/complete";

	public static string CLASSROOM_QUESTIONARY (int id) {
		return CLASSROOM + id + "/" + QUESTIONARY;
	}

	public static string QUESTIONARY_COMPLETE (int id) {
		return QUESTIONARY + id + COMPLETE;
	}

}
