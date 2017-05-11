using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class parkingButton : MonoBehaviour {

	void OnMouseDown()
	{

		SceneManager.LoadScene(2);
	}
}
