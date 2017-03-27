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

		ArrayList matrix = new ArrayList ();
		string[] lista1 = {"S","S","S","S","S","S","S","S","S","S"};
		string[] lista2 = {"UF","UE","UF","UF","S","RE","S","UF","UF","UE"};
		string[] lista3 = {"DF","DF","DF","DF","S","RF","S","DF","DF","DF"};
		string[] lista4 = {"S","S","S","S","S","S","S","S","S","S"};
		string[] lista5 = {"UF","S","UE","UF","UF","UF","S","UE","UF","UF"};

		matrix.Add (lista1);
		matrix.Add (lista2);
		matrix.Add (lista3);
		matrix.Add (lista4);
		matrix.Add (lista5);

		for(int i =0;i<(matrix.Count);i++){
			string[] lista = (string[]) matrix [i];
			for(int j=0;j<(lista.Length);j++){
				hayVertical = false;
				string inf = lista [j];
				string pos1 = "";
				string pos2 = "";

				//Si en la primera posicion hay una S, no hay segundo argumento
				//De lo contrario si hay segundo argumento
				if(inf.Substring(0,1).Equals("S")){
					pos1 = "S";
					posicionActual.x += espaciox;
				}else {
					pos1 = inf.Substring (0, 1);
					pos2 = inf.Substring (1);

					//Miramos la orientacion del parqueadero, luego miramos si esta lleno o vacio
					if(pos1.Equals("U")){
						if (pos2.Equals ("F")) {
							Instantiate (espaciosLlenos[Random.Range(0,espaciosLlenos.Length)],posicionActual,Quaternion.identity,transform);	
						} else {
							Instantiate (vacio,posicionActual,Quaternion.identity,transform);							
						}
						hayVertical = true;
						posicionActual.x += axh;
					}else if(pos1.Equals("R")){
						posicionActual.x += 0.28f;
						if (pos2.Equals ("F")) {
							Instantiate (espaciosLlenos[Random.Range(0,espaciosLlenos.Length)],posicionActual,Quaternion.Euler(0,0,-90),transform);							
						} else {
							Instantiate (vacio,posicionActual,Quaternion.Euler(0,0,-90),transform);
						}
						posicionActual.x += axv;
					}else if(pos1.Equals("D")){
						if (pos2.Equals ("F")) {
							Instantiate (espaciosLlenos[Random.Range(0,espaciosLlenos.Length)],posicionActual,Quaternion.Euler(0,0,180),transform);
						} else {
							Instantiate (vacio,posicionActual,Quaternion.Euler(0,0,180),transform);
						}
						hayVertical = true;
						posicionActual.x += axh;
					}else if(pos1.Equals("L")){
						if (pos2.Equals ("F")) {
							Instantiate (espaciosLlenos[Random.Range(0,espaciosLlenos.Length)],posicionActual,Quaternion.Euler(0,0,90),transform);
						} else {
							Instantiate (vacio,posicionActual,Quaternion.Euler(0,0,90),transform);
						}
						posicionActual.x += axv;
					}
				}
			}	
			if (hayVertical) {
				posicionActual.y += ayv;
				
			} else {
				posicionActual.y += ayh;
			}
			posicionActual.x = posicionInicial.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
