using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneButton : MonoBehaviour {

	GameObject parqueaderos;

	// Use this for initialization
	void Start () {
		parqueaderos = transform.Find ("parqueaderos").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{

		if (parqueaderos.activeSelf) {
			parqueaderos.SetActive (false);			
		} else {
			parqueaderos.SetActive (true);
		}
	}
}
