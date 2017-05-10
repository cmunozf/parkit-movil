using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadUser : MonoBehaviour {

	private string id;
	// Use this for initialization
	void Start () {
		id = parameters.getId();
		GetComponent<TextMesh>().text = id;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
