using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parameters : MonoBehaviour {

	private static string id;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake(){
		DontDestroyOnLoad(this);
	}

	public static string getId() {
		return id;
	}

	public static void setId(string id1) {
		id = id1;
	}
}
