using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loginButton : MonoBehaviour {

	public InputField inputFieldId;
	public InputField inputFielPass;

	private string id;
	private string pass;

	void OnMouseDown()
	{
		id = inputFieldId.text;
		parameters.setId(id);
		SceneManager.LoadScene(1);
	}
}
