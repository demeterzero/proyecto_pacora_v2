using UnityEngine;
using System.Collections;

public class EnableBuilding : MonoBehaviour {

	public int choice = 0;
	public GameObject casaChica, casaGrande, apartamento, granja, restaurante, super, policia, bombero, hospital, centroComercial, parque, escuela, basura, puerto, areaProtegida, oficinas, buses, metro;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (choice > 0) {

			switch (choice) {

			//CASA
			case 1:

				casaChica.SetActive (true);

				break;

			//MANSION
			case 2:

				casaGrande.SetActive (true);

				break;

			//APARTAMENTO
			case 3:

				apartamento.SetActive (true);

				break;

			//GRANJA
			case 4:

				granja.SetActive (true);

				break;

			//RESTAURANTE
			case 5:



				break;

			//SUPER
			case 6:



				break;

			//ESTACION POLICIA
			case 7:



				break;

			//ESTACION BOMBERO
			case 8:



				break;

			//HOSPITAL
			case 9:



				break;

			//CENTRO COMERCIAL
			case 10:



				break;

			//PARQUE
			case 11:



				break;

			//ESCUELA
			case 12:



				break;

			//BASURA
			case 13:



				break;

			//PUERTO
			case 14:



				break;

			//AREA PROTEGIDA
			case 15:



				break;

			//OFICINAS
			case 16:



				break;

			//BUSES
			case 17:



				break;

			//METRO
			case 18:



				break;
			}
	
			//Next code goes here
			//Destroy every other object not active
			foreach (Transform child in transform) {
			
				if (!child.gameObject.activeInHierarchy)
					Destroy (child.gameObject);
			
			}

			Destroy (this);

		}
	}
}
