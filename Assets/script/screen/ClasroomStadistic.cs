using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;

public class ClasroomStadistic : Base {

	public GameObject base_bar;
	public GameObject stadistic_container;

	public override void reload () {
		iRest.GET (Util.STADISTIC + getSession ().classroom._id, populate);
	}

	public bool populate (string json) {
		JSONNode _json = JSON.Parse (json);

		foreach (JSONNode stadistic in ((JSONArray)_json ["result"]["questions"])) {
			GameObject bar = Instantiate (base_bar);
			bar.transform.parent = stadistic_container.transform;

			bar.GetComponent <BarHandler> ().title.text = stadistic ["question"];

			float total = bar.GetComponent <BarHandler> ().total.parent.transform.GetComponent <RectTransform> ().sizeDelta.y;
			float top = ((total - bar.GetComponent <BarHandler> ().title.GetComponent <RectTransform> ().sizeDelta.y) * -1);
			bar.GetComponent <BarHandler> ().percentaje.offsetMax = new Vector2(
				bar.GetComponent <BarHandler> ().percentaje.offsetMax.x,
				top - int.Parse(stadistic ["correc_answers"]) * top / int.Parse(stadistic ["total_answers"])
			);
		}

		return true;
	}

}
