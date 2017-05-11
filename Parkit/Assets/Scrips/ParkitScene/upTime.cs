using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upTime : MonoBehaviour {

	public GameObject timeFloat;

	void OnMouseDown()
	{
		string time = timeFloat.GetComponent<TextMesh> ().text;
		float timeF = float.Parse(time);
		if(timeF<15){
			timeF = timeF + 1f;			
		}
		timeFloat.GetComponent<TextMesh> ().text = timeF + "";
		parameters.setTime (timeF);
	}
}
