using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loginButton : MonoBehaviour {

	public InputField inputFieldId;
	public InputField inputFielPass;

	private string id;
	private string pass;

	void OnMouseDown()
	{
		id = inputFieldId.text;
		parameters.setId(id);
		Application.LoadLevel("MainScene");
	}
}
