using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backButton : MonoBehaviour {

	void OnMouseDown()
	{
		Application.LoadLevel("MainScene");
	}
}
