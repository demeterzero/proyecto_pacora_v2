using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButton : MonoBehaviour {

	public string name = "", desc = "";
	//public Text prevText, descText;
	public int myChoice = 0, preview = 0, maxTurn = 0, cost = 0;
	public bool activePreview = false;
	public GameObject res, des, panel, mainObj;
	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
			
	}
	
	// Update is called once per frame
	void Update () {

		switch (preview) {

		//CASA
		case 1:

			name = "Casa Chicas";
			maxTurn = 2;
			cost = 200;
			desc = "Casas para que los interesados se muevan hacia la ciudad.\nProduce ingresos por cada residente nuevo.";

			break;

			//MANSION
		case 2:

			name = "Casa Grande";
			maxTurn = 5;
			cost = 300;
			desc = "Casas para que los interesados se muevan hacia la ciudad.\nProduce mas ingresos que las casas chicas, pero tiene menos capacidad para residentes.";

			break;

			//APARTAMENTO
		case 3:

			name = "Apartamentos";
			maxTurn = 4;
			cost = 400;
			desc = "Apartamentos para que los interesados se muevan hacia la ciudad.\nPermite una capacidad mayor, pero consume recursos hídricos.";

			break;

			//GRANJA
		case 4:

			name = "Granja";
			maxTurn = 2;
			cost = 200;
			desc = "Estructura básica que provee comida y aumenta la felicidad de la cuidad.\nProvee trabajos.";

			break;

			//RESTAURANTE
		case 5:

			name = "Restaurante";
			maxTurn = 3;
			cost = 250;
			desc = "Estructura de recreación que aumenta la felicidad de la ciudad.\nProvee trabajos.";

			break;

			//SUPER
		case 6:

			name = "Supermercado";
			maxTurn = 4;
			cost = 300;
			desc = "Estructura avanzada que aumenta la felicidad bastante, pero require 2 Granjas por cada uno.\nProvee trabajos.";

			break;

			//ESTACION POLICIA
		case 7:

			name = "Estación de Policía";
			maxTurn = 3;
			cost = 300;
			desc = "Edificio gubernamental para la protección ciudadana.\nProvee trabajos.";

			break;

			//ESTACION BOMBERO
		case 8:

			name = "Estación de Bomberos";
			maxTurn = 3;
			cost = 300;
			desc = "Edificio gubernamental para contratacar desastres en la ciudad.\nProvee trabajos.";

			break;

			//HOSPITAL
		case 9:

			name = "Hospital";
			maxTurn = 3;
			cost = 400;
			desc = "Edificio gubernamental que provee necesidades médicas de la ciudadanía.\nProvee trabajos.";

			break;

			//CENTRO COMERCIAL
		case 10:

			name = "Centro Comercial";
			maxTurn = 6;
			cost = 500;
			desc = "Construcción grande que provee todo tipos de servicios, aumentando la felicidad de la ciudad bastante.\nProvee trabajos.";

			break;

			//PARQUE
		case 11:

			name = "Parque";
			maxTurn = 2;
			cost = 300;
			desc = "Provee areas verdes en la ciudad, aumentando la felicidad de todas las residencias cercanas y el índice de naturaleza por un poco.";

			break;

			//ESCUELA
		case 12:

			name = "Escuela";
			maxTurn = 2;
			cost = 250;
			desc = "Institución educacional para los niños y adolescentes.\nProvee trabajos";

			break;

			//BASURA
		case 13:

			name = "Centro de Reciclaje";
			maxTurn = 4;
			cost = 300;
			desc = "Deposito y eliminación de basuras de la ciudad.\nProvee trabajos";

			break;

			//PUERTO
		case 14:

			name = "Puerto";
			maxTurn = 6;
			cost = 500;
			desc = "Permite tener un muelle de botes en la ciudad y tránsito acuático. Necesita ser construido en la costa.\nProvee trabajos.";

			break;

			//AREA PROTEGIDA
		case 15:

			name = "Delegar Area Protegida";
			maxTurn = 4;
			cost = 300;
			desc = "Permite la retención y protección de las áreas verdes, aumentando el índice de naturaleza de la ciudad.";

			break;

			//OFICINAS
		case 16:

			name = "Oficinas";
			maxTurn = 4;
			cost = 400;
			desc = "Edificios grandes que proveen multiples trabajos.";

			break;

			//BUSES
		case 17:

			name = "Centro de Buses";
			maxTurn = 4;
			cost = 400;
			desc = "Permite introducir un sistema público de transporte para los ciudadanos.\nProvee trabajos.";

			break;

			//METRO
		case 18:

			name = "Metro";
			maxTurn = 5;
			cost = 500;
			desc = "Creación de túneles subteráneos en la ciudad para el uso del Metro.\nProvee trabajos.";

			break;

		}

		if (activePreview) {
			res.GetComponent<Text> ().text = name + " - Cost: $" + cost + " - Meses: " + maxTurn;
			des.GetComponent<Text> ().text = desc;
		}

		if(preview == -1){
			res.GetComponent<Text>().text = "FONDOS INSUFICIENTES";
			des.GetComponent<Text> ().text = "Consejo: Trata de construir y vender residencias, ya que este es la mejor forma de recibir dinero.";			
		}
	
		//EXIT BY ESCAPE
		if (Input.GetKey (KeyCode.Escape) && mainObj.GetComponent<BuildLogic>().mc.GetComponent<CameraMovement>().isSelect == true) {

			ExitUI ();

		}

	}

	public void MouseIn(int p){
		try{

			preview = p;
			activePreview = true;

			anim.SetBool ("Highlighted", true);
		}
		catch {
			//print ("The error triggered, but its ok!");
		}
		//print ("selected!");

	}
		
	public void MouseOut(){

		anim.SetBool ("Highlighted", false);
		name = "";
		cost = 0;
		maxTurn = 1;
		res.GetComponent<Text>().text = "";
		des.GetComponent<Text> ().text = "";
		preview = 0;
		activePreview = false;

	}

	public void OnMouseDown(int c){

		//print ("I am pressed!");

		myChoice = c;

		mainObj.GetComponent<BuildLogic> ().ChoseBuild (myChoice);

		//IF THERE IS NOT ENOUGH MONEY, ENABLE LACK OF MONEY PREVIEW
		if (mainObj.GetComponent<BuildLogic> ().mgl.money < cost) {

			preview = -1;

			//SFX is missing of lack of monay

		}

	}

	public void ExitUI(){

		mainObj.GetComponent<BuildLogic>().mc.GetComponent<CameraMovement>().isSelect = false;
		panel.SetActive (false);

	}

}
