using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Base : MonoBehaviour {
	
	protected UIBehaviour uiBehaviour;
	protected REST iRest;
	private Session sess;
	protected SClassroom classR;

	void Start () {
		uiBehaviour = transform.GetComponent <UIBehaviour> ();
		iRest = transform.GetComponent <REST> ();
		sess = transform.GetComponent <Session> ();
		classR = transform.GetComponent <SClassroom> ();
	}

	public virtual void reload () {}

	public Session getSession () {
		return sess;
	}

}
