using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llenarParqueadero : MonoBehaviour {

	public GameObject[] espaciosLlenos;

	public GameObject vacio;

	private Vector3 posicionInicial;
	private Vector3 posicionActual;

	private float axh = 1.27f;
	private float ayh = -1.26f;
	private float espaciox = 1.5f;

	private float axv = 1.7f;
	private float ayv = -2f;
	private bool hayVertical = false;

	public string json;
	public ParqueaderoData parqueaderoData;

	// Use this for initialization

	/*Primer letra: posicion parqueadero
	 * R: Derecha
	 * I: Izquierda
	 * U: Arriba
	 * D: Abajo
	 * S: Calle (No hay segundo arguento)
	 * 
	 * Segundo argumento
	 * F: Lleno
	 * E: Vacio
	 */

	void Start () {
		Llenar ();		
	}

	void Llenar(){
		posicionInicial = transform.position;
		posicionActual = posicionInicial;

		string url = "https://intense-eyrie-97315.herokuapp.com/parkings/parking_info"; 
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			json = www.text;
			foreach (Transform child in transform) {
				GameObject.Destroy (child.gameObject);
			}
			Generar ();
			Debug.Log("WWW Ok!: " + www.text);

		} else {
			Debug.Log("WWW Error: "+ www.error);
		} 

		//Se mira el tiempo de actualizacion que el usuario requiera, a este se le resta un segundo
		//Para que un segundo antes se vaya haciendo la peticion del nuevo parqueadero (Ya que 
		// este es un poco lento al devolver la peticion)
		float time = parameters.getTime ();
		time = time - 1f;
		Debug.Log ("Invoke en: "+ time + "Time: "+System.DateTime.Now);
		CancelInvoke ();
		Invoke ("Llenar",time);
	}

	void Generar(){
		parqueaderoData = JsonUtility.FromJson<ParqueaderoData> (json);
		for(int i =0;i<(parqueaderoData.parqueaderos.Count);i++){
			Parqueadero p =	parqueaderoData.parqueaderos [i];
			string dir = p.direccion;
			string est = p.estado;

			if(est.Equals("S")){
				posicionActual.x += espaciox;
			}else {
				//Miramos la orientacion del parqueadero, luego miramos si esta lleno o vacio
				if(dir.Equals("U")){
					if (est.Equals ("F")) {
						Instantiate (espaciosLlenos[Random.Range(0,espaciosLlenos.Length)],posicionActual,Quaternion.identity,transform);	
					} else {
						Instantiate (vacio,posicionActual,Quaternion.identity,transform);							
					}
					posicionActual.x += axh;
					hayVertical = true;
				}else if(dir.Equals("R")){
					posicionActual.x += 0.28f;
					if (est.Equals ("F")) {
						Instantiate (espaciosLlenos[Random.Range(0,espaciosLlenos.Length)],posicionActual,Quaternion.Euler(0,0,-90),transform);							
					} else {
						Instantiate (vacio,posicionActual,Quaternion.Euler(0,0,-90),transform);
					}
					posicionActual.x += axv;
				}else if(dir.Equals("D")){
					if (est.Equals ("F")) {
						Instantiate (espaciosLlenos[Random.Range(0,espaciosLlenos.Length)],posicionActual,Quaternion.Euler(0,0,180),transform);
					} else {
						Instantiate (vacio,posicionActual,Quaternion.Euler(0,0,180),transform);
					}
					posicionActual.x += axh;
					hayVertical = true;
				}else if(dir.Equals("L")){
					if (est.Equals ("F")) {
						Instantiate (espaciosLlenos[Random.Range(0,espaciosLlenos.Length)],posicionActual,Quaternion.Euler(0,0,90),transform);
					} else {
						Instantiate (vacio,posicionActual,Quaternion.Euler(0,0,90),transform);
					}
					posicionActual.x += axv;
				}
			}

			int contador = i;
			contador++;
			if(parqueaderoData.parqueaderos.Count>contador){
				Parqueadero p1 =	parqueaderoData.parqueaderos [contador];
				if(p1.y>p.y){
					posicionActual.x = posicionInicial.x;
					if (hayVertical) {
						posicionActual.y += ayv;						
					} else {
						posicionActual.y += ayh;						
					}
					hayVertical = false;
				}				
			}

		}	

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[System.Serializable]
	public class Parqueadero
	{
		public int x;
		public int y;
		public string estado;
		public string direccion;

	}
	[System.Serializable]
	public class ParqueaderoData
	{
		public List<Parqueadero> parqueaderos;
	}
}
	
