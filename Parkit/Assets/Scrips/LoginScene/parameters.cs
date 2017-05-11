using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parameters : MonoBehaviour {

	private static string id;
	private static float time = 5f;
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

	public static float getTime() {
		return time;
	}

	public static void setTime(float time1) {
		time = time1;
	}
}
