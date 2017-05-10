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
		
		posicionInicial = transform.position;
		posicionActual = posicionInicial;

		string url = "https://intense-eyrie-97315.herokuapp.com/parkings/parking_info";
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));

		//json = "{\n  \"parqueaderos\":\n  [\n    {\n    \"x\":0,\n    \"y\":0,\n    \"estado\":\"E\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":1,\n    \"y\":0,\n    \"estado\":\"F\",\n    \"direccion\":\"U\"\n  },\n   {\n    \"x\":2,\n    \"y\":0,\n    \"estado\":\"F\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":3,\n    \"y\":0,\n    \"estado\":\"F\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":4,\n    \"y\":0,\n    \"estado\":\"E\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":5,\n    \"y\":0,\n    \"estado\":\"F\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":6,\n    \"y\":0,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":7,\n    \"y\":0,\n    \"estado\":\"F\",\n    \"direccion\":\"L\"\n  },\n  {\n    \"x\":0,\n    \"y\":1,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":1,\n    \"y\":1,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n   {\n    \"x\":2,\n    \"y\":1,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":3,\n    \"y\":1,\n    \"estado\":\"E\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":4,\n    \"y\":1,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":5,\n    \"y\":1,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":6,\n    \"y\":1,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":7,\n    \"y\":1,\n    \"estado\":\"E\",\n    \"direccion\":\"L\"\n  },\n  {\n    \"x\":0,\n    \"y\":2,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":1,\n    \"y\":2,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n   {\n    \"x\":2,\n    \"y\":2,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":3,\n    \"y\":2,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":4,\n    \"y\":2,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":5,\n    \"y\":2,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":6,\n    \"y\":2,\n    \"estado\":\"S\",\n    \"direccion\":\"U\"\n  },\n  {\n    \"x\":0,\n    \"y\":3,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":1,\n    \"y\":3,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n   {\n    \"x\":2,\n    \"y\":3,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":3,\n    \"y\":3,\n    \"estado\":\"E\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":4,\n    \"y\":3,\n    \"estado\":\"F\",\n    \"direccion\":\"D\"\n  },\n  {\n    \"x\":5,\n    \"y\":3,\n    \"estado\":\"E\",\n    \"direccion\":\"R\"\n  }\n  ]\n}";

	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			json = www.data;
			generar ();
			Debug.Log("WWW Ok!: " + www.data);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	void generar(){
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
	
