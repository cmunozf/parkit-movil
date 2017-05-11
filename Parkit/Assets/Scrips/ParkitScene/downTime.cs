using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downTime : MonoBehaviour {

	public GameObject timeFloat;

	void OnMouseDown()
	{
		string time = timeFloat.GetComponent<TextMesh> ().text;
		float timeF = float.Parse(time);
		if(timeF>4){
			timeF = timeF - 1f;			
		}
		timeFloat.GetComponent<TextMesh> ().text = timeF + "";
		parameters.setTime (timeF);
	}
}
