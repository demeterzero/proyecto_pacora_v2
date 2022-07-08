using UnityEngine;
using System.Collections;

public class BuildLogic : MonoBehaviour {

	public int whatChoice = 0, curTurn = 0, maxTurn = 1, cost = 0;
	public float yOffset = 1;
	public bool wasSelected = false, isDone = false, killChild = false;
	public GameList mgl;
	public GameObject mc, panel, baseBuild, refPoint;
	//public GameObject consObj, casaChica, casaGrande, apartamento, granja, restaurante, super, policia, bombero, hospital, centroComercial, parque, escuela, basura, puerto, areaProtegida, oficinas, buses, metro;

	// Use this for initialization
	void Start () {

		//mgl = GameObject.FindGameObjectWithTag("Main").GetComponent<GameList>();
		//mc = GameObject.FindGameObjectWithTag ("MainCamera");
		panel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		//SPAWN LOGIC

		if (curTurn == maxTurn && wasSelected && !isDone && killChild) {

			Destroy (refPoint.gameObject);

			this.gameObject.transform.GetChild(0).transform.FindChild("BuildingArray").GetComponent<EnableBuilding> ().choice = whatChoice;

			//Locks the switch so it does not happen multiple times
			isDone = true;

		}
			
		//IF THE FIRST TURN COMES AND THE ANIMATION HAS NOT STARTED, START IT!
		if (curTurn == 1 && !this.gameObject.GetComponent<Animator> ().GetBool ("ChopDown"))
			this.gameObject.GetComponent<Animator> ().SetBool ("ChopDown", true);

		//Logic to kill every child and spawn the new GameObject
		if (!killChild && curTurn > 0 && this.gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !this.gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo(0).IsName("Empty")) {

			foreach (Transform child in transform) {

				Destroy (child.gameObject);

			}

			GameObject x = (GameObject)Instantiate (baseBuild, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + yOffset, this.gameObject.transform.position.z), Quaternion.identity);

			x.transform.parent = gameObject.transform;

			killChild = true;

			}
	}


	public void ChoseBuild(int gc){

		//UI CHOICE LOGIC
		//print("I am inside this function...");

		whatChoice = gc;

		if(whatChoice > 0 && !wasSelected){

			cost = 0;

			switch (whatChoice) {

			//CASA
			case 1:

				maxTurn = 2;
				cost -= 200;

				break;

				//MANSION
			case 2:

				maxTurn = 5;
				cost -= 300;

				break;

				//APARTAMENTO
			case 3:

				maxTurn = 4;
				cost -= 400;

				break;

				//GRANJA
			case 4:

				maxTurn = 2;
				cost -= 200;

				break;

				//RESTAURANTE
			case 5:

				maxTurn = 3;
				cost -= 250;

				break;

				//SUPER
			case 6:

				maxTurn = 4;
				cost -= 300;

				break;

				//ESTACION POLICIA
			case 7:

				maxTurn = 3;
				cost -= 300;

				break;

				//ESTACION BOMBERO
			case 8:

				maxTurn = 3;
				cost -= 300;

				break;

				//HOSPITAL
			case 9:

				maxTurn = 3;
				cost -= 400;

				break;

				//CENTRO COMERCIAL
			case 10:

				maxTurn = 6;
				cost -= 500;

				break;

				//PARQUE
			case 11:

				maxTurn = 2;
				cost -= 300;

				break;

				//ESCUELA
			case 12:

				maxTurn = 2;
				cost -= 250;

				break;

				//BASURA
			case 13:

				maxTurn = 4;
				cost -= 300;

				break;

				//PUERTO
			case 14:

				maxTurn = 6;
				cost -= 500;

				break;

				//AREA PROTEGIDA
			case 15:

				maxTurn = 4;
				cost -= 300;

				break;

				//OFICINAS
			case 16:

				name = "Oficinas";
				maxTurn = 4;
				cost -= 400;

				break;

				//BUSES
			case 17:

				name = "Centro de Buses";
				maxTurn = 4;
				cost -= 400;

				break;

				//METRO
			case 18:

				name = "Metro";
				maxTurn = 5;
				cost -= 500;

				break;
			}

			//Do next function to see if the player counts with the proper resources
			CommitBuild ();


		}
			
	}

	//Function called to see if player has enough money or not to commmit action
	public void CommitBuild(){

		if (mgl.money + cost >= 0) {
			
			//print ("We can build it!");

			mgl.money += cost;
			mgl.build.Add (this.gameObject);
			wasSelected = true;
			mc.GetComponent<CameraMovement> ().isSelect = false;
			Destroy (panel);

		} else {
			//Say there isint enough money
			//print ("Not enough cash, stranger!");

			maxTurn = 1;
			whatChoice = 0;
			cost = 0;
		}

	}

	//Function to activate UI
	void OnMouseUp(){

		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
		if (Physics.Raycast(ray, out hit, 100.0f) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && !mc.GetComponent<CameraMovement> ().isSelect && !wasSelected) {

			mc.GetComponent<CameraMovement> ().isSelect = true;
			panel.SetActive (true);

		}
	
	}

}