using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainSelect : MonoBehaviour {

	public Texture background, backDef, leafBack, axeBack, hammerBack, clean, cleanS, protect, protectS, niceCut, niceCutS, fastCut, fastCutS, house, houseS, bigHouse, bigHouseS, shop, shopS, farm, farmS, leafHouse, leafHouseS, movie, movieS; // leaf, hammer, axe;
	public GameObject leaf, leafChild, hammer, hammerChild, axe, axeChild;
	public GameObject buildChild, relleno, houseSmall, houseBig, farmStore, shopStore, movieStore, leafBuilding; //STUFF TO BUILD GOES HERE
	public Animation anim;
	public AudioClip click, hammerSFX, axeSFX, leafSFX;
	public AudioSource audio;
	public GUIStyle leafStyle, hammerStyle, axeStyle, bosqueText, rellenoText, insuficiente, tooltipStyle;
	public bool isTouch = false, startGUI = false, lockTouch = false, isFinished = false, canBeProtected = false, isWoods = true, isBuilding = false, isMangrooves = false;
	//IS FINISHED to lock construction mode on this panel
	//CAN BE PROTECTED to inform that it has already been cleaned
	public int leafGrid=0, axeGrid=0, hammerGrid=0, curCons=1, finCons =0, turns = 0, capSmall = 0, capBig = 0, cost = 0, whichMangroove = 0;
	public float happyModifier, happyModifierNow, qualityModifier, natureModifier, natureModifierNow; 

	public GameObject mainLog;

	private GameObject objBuild;
	private int set, childCount, i, leafState = 0;
	private float ts = 0, timBuild = 1.2f;
	private bool letsBuild = false;
	private string name, mangrooveName="";
	private Vector3 daddy, vecBuild;
	private Quaternion rotBuild;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();

		mainLog = GameObject.Find ("MainGameLogic");

		daddy = this.gameObject.transform.position;

		anim = GetComponentInChildren<Animation> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (isWoods) {

			if(isMangrooves){

				switch(whichMangroove){
				case 1:
					mangrooveName=" Rojo ";
					break;
				case 2:
					mangrooveName=" Blanco ";
					break;
				case 3:
					mangrooveName=" Negro ";
					break;
				case 4:
					mangrooveName=" Piñuelo ";
					break;
				}

				switch(leafState){
				case 0:
					//name = "Manglar"+mangrooveName;
					name = "Manglar"+mangrooveName;

					break;
				case 1:
					//name = "Manglar"+mangrooveName+"Limpio";
					name = "Manglar"+mangrooveName+"Limpio";
					break;
				case 2:
					//name = "Manglar"+mangrooveName+"Protegido";
					name = "Manglar"+mangrooveName+"Protegido";
					break;
					}

			}else{

				switch(leafState){
				case 0:
					//name = "Bosque";
					name = "Bosque";
					break;
				case 1:
					//name = "Bosque Limpio";
					name = "Bosque Limpio";
					break;
				case 2:
					//name = "Bosque Protegido";
					name = "Bosque Protegido";
					break;
				}

			}
			/*
			if(canBeProtected){
				name = "Bosque Limpio";}

			if(canBeProtected && isFinished){
				name = "Bosque Protegido";}
			else{
				name = "Bosque";}*/
		} else  if (hammerGrid > 0 && isFinished) {
			name = name;
		}else{
			//name = "Relleno";
			name = "Relleno";
		}

		//LOGIC FOR WHEN IT IS CLICKED STARTS HERE
		if (isTouch && Input.GetMouseButtonDown (0) && mainLog.GetComponent<ControlCheck>().haveSelected == false && curCons >= finCons && isFinished == false) {

			audio.PlayOneShot(click, 0.5f);

			set = 0;

			startGUI = true;

			background = backDef;

			lockTouch = true;

			mainLog.GetComponent<ControlCheck>().haveSelected = true;
			mainLog.GetComponent<Watch>().isCounting = false;

			ResetValues();

		}

		////////////////////////////////////////////////PROCESS WHILE BEING BUILD GOES HERE/////////////////////////////////////////////

		if (letsBuild) {
			InstantiateAfterAWhile(objBuild, vecBuild, rotBuild, timBuild);
		}

		if (finCons > curCons) {
			curCons = mainLog.GetComponent<Watch> ().currentTurn;
		}

		//PROCESS WHEN BUILDING IS DONE
		if (curCons == finCons && isBuilding) {

			isBuilding = false;

			if(axeGrid > 0 || hammerGrid > 0){

				letsBuild = true;
				anim.Play("DownAndUp");

				childCount = transform.childCount;

				for(i=childCount -1; i >= 0; i--){

					//GetComponentInChildren<Transform>().position.x += daddy.x;
					//GetComponentInChildren<Transform>().transform.position.y += daddy.y;
					//GetComponentInChildren<Transform>().transform.position.z += daddy.z;

					//anim.Play("DownAndUp2");
					Destroy(transform.GetChild(i).gameObject, 0.3f);

				}
			}

			//yield return new WaitForSeconds(0.65f);

			if(leafGrid > 0){
				Destroy(leafChild);
				mainLog.GetComponent<GameScore>().nature += natureModifier;
				leafState++;

				switch(leafGrid){
				case 1:
					canBeProtected = true;
					break;

				case 2:
					isFinished = true;
					break;

				}

				//if(leafGrid == 2){
				//	isFinished = true;
					//name = name+" Protegido";
				//}

					}

			if(axeGrid > 0){
				isWoods = false;

				objBuild = relleno;
				vecBuild = new Vector3(daddy.x, -0.2f, daddy.z);
				rotBuild = Quaternion.Euler(270,0,0);
				//timBuild = 0.85f;

				//InstantiateAfterAWhile(relleno, new Vector3(daddy.x, -0.2f, daddy.z), Quaternion.Euler(270,0,0), 0.65f);

				//Invoke(
			 	//buildChild = Instantiate(relleno, new Vector3(daddy.x, -0.2f, daddy.z), Quaternion.Euler(270,0,0)) as GameObject;
				//buildChild.transform.parent = this.gameObject.transform;
				Destroy(axeChild);
					}

			if(hammerGrid > 0){
				Destroy(hammerChild);

				switch(hammerGrid){

				case 1:

					objBuild = houseSmall;
					vecBuild = new Vector3(daddy.x, 0.06f, daddy.z);
					rotBuild = Quaternion.Euler(0,0,0);
					//name = "Casas Chicas";
					name = "Casas Chicas";
					mainLog.GetComponent<GameScore>().smallHouseMax += capSmall;
					mainLog.GetComponent<GameScore>().houseCount++;

					break;

				case 2:

					objBuild = houseBig;
					vecBuild = new Vector3(daddy.x, 0.06f, daddy.z);
					rotBuild = Quaternion.Euler(0,0,0);
					//name = "Casas Grandes";
					name = "Casas Grandes";
					mainLog.GetComponent<GameScore>().bigHouseMax += capBig;
					mainLog.GetComponent<GameScore>().houseBigCount++;

					break;

				case 3:

					objBuild = farmStore;
					vecBuild = new Vector3(daddy.x, 0.06f, daddy.z);
					rotBuild = Quaternion.Euler(0,0,0);
					//name = "Granja";
					name = "Granja";
					mainLog.GetComponent<GameScore>().farmCount++;

					break;

				case 4:

					objBuild = shopStore;
					vecBuild = new Vector3(daddy.x, 0.06f, daddy.z);
					rotBuild = Quaternion.Euler(0,0,0);
					//name = "Supermercado";
					name = "Supermercado";
					//mainLog.GetComponent<GameScore>().shopCount++;

					break;

				case 5:

					objBuild = leafBuilding;
					vecBuild = new Vector3(daddy.x, 0.06f, daddy.z);
					rotBuild = Quaternion.Euler(0,0,0);
					//name = "Edificio Verde";
					name = "Edificio Verde";
					mainLog.GetComponent<GameScore>().greenCount++;
					mainLog.GetComponent<GameScore>().canCleanCity = true;

					break;

				case 6:

					objBuild = movieStore;
					vecBuild = new Vector3(daddy.x, 0.06f, daddy.z);
					rotBuild = Quaternion.Euler(0,0,0);
					//name = "Cine";
					name = "Cine";
					mainLog.GetComponent<GameScore>().movieCount++;

					break;


				}

				isFinished = true;
					}

			if(natureModifier > 0){
				mainLog.GetComponent<GameScore>().nature += natureModifier;
				natureModifier = 0;
			}
			if(happyModifier > 0){
				mainLog.GetComponent<GameScore>().happy += happyModifier;
				happyModifier = 0;
			}

			//mainLog.GetComponent<GameScore>().quality += qualityModifier;
		}
	
	}

	//LATE UPDATE GOES HERE!!!
	void LateUpdate(){

		if (anim.isPlaying) {
			transform.localPosition += daddy;
		} else {
			transform.localPosition = daddy;
		}

	}

	void OnGUI(){

		//NAME FOR HOVERING APPEARS HERE
		if (isTouch && mainLog.GetComponent<ControlCheck>().haveSelected == false) {

			GUI.Box(new Rect(Event.current.mousePosition.x + 30, Event.current.mousePosition.y - 30, 150, 25), name);

		}

		//ACTUAL GUI LOGIC GOES HERE
		if (startGUI) {

			GUI.BeginGroup(new Rect(Screen.width/3 + 20, Screen.height/8, 300, 450));

			GUI.DrawTexture (new Rect (0, 0, 300, 450), background, ScaleMode.StretchToFill, true, 1.0f);

			if(isWoods){
				//GUI.Label(new Rect(0,20,300,60), "Arboles", bosqueText);}
				GUI.Label(new Rect(0,20,300,60), "Arboles", bosqueText);}
			else{
				//GUI.Label(new Rect(0,20,300,60), "[Relleno]", rellenoText);
				GUI.Label(new Rect(0,20,300,60), "[Relleno]", rellenoText);
			}

			if(isWoods){

				if(GUI.Button(new Rect(60, 100, 64, 64), "", leafStyle)){
					background = leafBack;
					set = 1;
					audio.PlayOneShot(click, 0.5f);
					ResetValues();
				}

				if(GUI.Button(new Rect(180, 100, 64, 64), "", axeStyle)){
					background = axeBack;
					set = 2;
					audio.PlayOneShot(click, 0.5f);
					ResetValues();
				}

			}
			else{

				if(GUI.Button(new Rect(120, 100, 64, 64), "", hammerStyle)){
					background = hammerBack;
					set = 3;
					audio.PlayOneShot(click, 0.5f);
					ResetValues();
				}

			}

			//SET TO DECIDE THE BUTTONS THAT APPEAR IN THE GUI MENU FOR CONSTRUCTIONS AND SO
			switch(set){

			case 0:
				//NOTHING GOES HERE!
				break;

			case 1: //LEAF SET

				if(leafGrid == 1){

					if(mainLog.GetComponent<GameScore>().canCleanCity && GUI.Button(new Rect(15, 200, 128, 128), new GUIContent(cleanS, "LIMPIEZA COMUNITARIA:\n\nLímpia la región de bosque escogida.\n\nCosto: 75\n\nTurnos: 2\n\nDa: +0.5 Naturaleza\n\nRequire: Edificio Ecológico\n*Se pierde al ser destruida*"))){
					//if(mainLog.GetComponent<GameScore>().canCleanCity && GUI.Button(new Rect(15, 200, 128, 128), new GUIContent(cleanS, "COMMUNITY CLEANING:\n\nCleans the selected area.\n\nCost: 75\n\nTurns: 2\n\nGives: +0.5 Nature\n\nRequires: Green House\n*Bonus lost if destroyed*"))){
						//leafGrid = 1;
						audio.PlayOneShot(click, 0.5f);
				}

				}
				else{

					if(mainLog.GetComponent<GameScore>().canCleanCity && GUI.Button(new Rect(15, 200, 128, 128), new GUIContent(clean, "LIMPIEZA COMUNITARIA:\n\nLímpia la región de bosque escogida.\n\nCosto: 75\n\nTurnos: 2\n\nDa: +0.5 Naturaleza\n\nRequire: Edificio Ecológico\n*Se pierde al ser destruida*"))){
					//if(mainLog.GetComponent<GameScore>().canCleanCity && GUI.Button(new Rect(15, 200, 128, 128), new GUIContent(clean, "COMMUNITY CLEANING:\n\nCleans the selected area.\n\nCost: 75\n\nTurns: 2\n\nGives: +0.5 Nature\n\nRequires: Green House\n*Bonus lost if destroyed*"))){
						if(!canBeProtected){

							leafGrid = 1;
							turns = 2;
							natureModifier = 0.5f;
							cost = -75;
							audio.PlayOneShot(click, 0.5f);


						}
						else{
							leafGrid = 0;
						}
					}
				}

				if(leafGrid == 2){

					if(mainLog.GetComponent<GameScore>().canCleanCity && GUI.Button(new Rect(160, 200, 128, 128), new GUIContent(protectS, "DELEGAR ÁREA PROTEGIDA:\n\nSe asigna la región como una área protegida - no se puede destruir.\n\nCosto: 100\n\nTurnos: 6\n\nDa: +1.5 Naturaleza\n\nRequiere: Limpieza"))){
					//if(mainLog.GetComponent<GameScore>().canCleanCity && GUI.Button(new Rect(160, 200, 128, 128), new GUIContent(protectS, "DECLARE PROTECTED AREA:\n\nSelected area is set as protected - it cannot be demolished..\n\nCost: 100\n\nTurns: 6\n\nGives: +1.5 Nature\n\nRequires: Community Cleaning"))){
						//leafGrid = 2;
						audio.PlayOneShot(click, 0.5f);
					}

				}
				else{

					if(mainLog.GetComponent<GameScore>().canCleanCity && GUI.Button(new Rect(160, 200, 128, 128), new GUIContent(protect, "DELEGAR ÁREA PROTEGIDA:\n\nSe asigna la región como una área protegida - no se puede destruir.\n\nCosto: 100\n\nTurnos: 6\n\nDa: +1.5 Naturaleza\n\nRequiere: Limpieza"))){

						if(canBeProtected){

							leafGrid = 2;
							turns = 6;
							natureModifier = 1.5f;
							cost = -100;
							audio.PlayOneShot(click, 0.5f);
						}
						else{
							//DO LOGIC FOR UNPROTECTED FOREST HERE
							leafGrid = 0;
							audio.PlayOneShot(click, 0.5f);
						}
					}

				}
				break;

			case 2: //CUTTING DOWN SET

				if(axeGrid == 1){

					if(GUI.Button(new Rect(15, 200, 128, 128), new GUIContent(niceCutS, "CORTAR BOSQUE:\n\nCorte de bosque de forma correcta - mas amigable al medio ambiente pero toma mas tiempo.\n\nCosto: 200\n\nTurnos: 2\n\nDa: -0.5 Naturaleza \nSe reemplaza el bosque por relleno."))){
					//if(GUI.Button(new Rect(15, 200, 128, 128), new GUIContent(niceCutS, "CUT FOREST:\n\nCuts down forest as environment-friendly as possilbe - takes longer.\n\nCost: 200\n\nTurns: 2\n\nGives: -0.5 Nature \n*Is replaced with a Landfill*"))){
						//axeGrid = 1;
						audio.PlayOneShot(click, 0.5f);
					}

				}
				else{

					if(GUI.Button(new Rect(15, 200, 128, 128), new GUIContent(niceCut, "CORTAR BOSQUE:\n\nCorte de bosque de forma correcta - mas amigable al medio ambiente pero toma mas tiempo.\n\nCosto: 200\n\nTurnos: 2\n\nDa: -0.5 Naturaleza \nSe reemplaza el bosque por relleno."))){
						axeGrid = 1;
						turns = 2;
						cost = -200;
						audio.PlayOneShot(click, 0.5f);

						if(canBeProtected){
							natureModifierNow = -1.0f;}
						else{
							natureModifierNow = -0.5f;}

						if(isMangrooves){
							natureModifierNow += -2.5f;
						}

					}

				}

				if(axeGrid == 2){

					if(GUI.Button(new Rect(160, 200, 128, 128), new GUIContent(fastCutS, "DESTRUIR BOSQUE:\n\nCorte de bosque de forma rápida - no es amigable al medio ambiente pero es efectivo.\n\nCosto: 450\n\nTurnos: 1\n\nDa: -1.5 Naturaleza \nSe reemplaza el bosque por relleno."))){
					//if(GUI.Button(new Rect(160, 200, 128, 128), new GUIContent(fastCutS, "DESTROY FOREST:\n\nCuts the forest in a hastedly fashion - not eco-friendly.\n\nCost: 450\n\nTurns: 1\n\nGives: -1.5 Nature \nIs replaced with a Padding."))){
						//axeGrid = 2;
						audio.PlayOneShot(click, 0.5f);
					}

				}
				else{

					if(GUI.Button(new Rect(160, 200, 128, 128), new GUIContent(fastCut, "DESTRUIR BOSQUE:\n\nCorte de bosque de forma rápida - no es amigable al medio ambiente pero es efectivo.\n\nCosto: 450\n\nTurnos: 1\n\nDa: -1.5 Naturaleza \nSe reemplaza el bosque por relleno."))){
						axeGrid = 2;
						turns = 1;
						cost = -450;
						audio.PlayOneShot(click, 0.5f);

						if(canBeProtected){
							natureModifierNow = -2.0f;}
						else{
							natureModifierNow = -1.5f;}

						if(isMangrooves){
							natureModifierNow += -2.5f;
						}

					}

				}
				break;

			case 3:///////////////////////////////////////////////////////CONSTRUCTION SET//////////////////////////////////////////////////////////////////////////////////////////

				if(hammerGrid == 1){
					if(GUI.Button(new Rect(30, 200, 64,64), new GUIContent(houseS, "CASAS CHICAS:\n\nConstrucción básica de casas. Generan ingresos y permite que personas vivan en la ciudad.\n\nCosto: 400\n\nTurnos: 2\n\nDa: 15 dólares por venta\nCapacidad: 100"))){
					//if(GUI.Button(new Rect(30, 200, 64,64), new GUIContent(houseS, "SMALL HOUSES:\n\nBasic house construction. Generates income by allowing new people to move into the city.\n\nCost: 400\n\nTurns: 2\n\nGives: 15 money per sale\nCapacity: 100"))){
						audio.PlayOneShot(click, 0.5f);
					}
				}
				else{
					if(GUI.Button(new Rect(30, 200, 64,64), new GUIContent(house, "CASAS CHICAS:\n\nConstrucción básica de casas. Generan ingresos y permite que personas vivan en la ciudad.\n\nCosto: 400\n\nTurnos: 2\n\nDa: 15 dólares por venta\nCapacidad: 100"))){
						hammerGrid = 1;
						turns = 2;
						capSmall = 100;
						cost = -400;
						audio.PlayOneShot(click, 0.5f);
					}
				}



				if(hammerGrid == 2){
					if(mainLog.GetComponent<GameScore>().canBigHouse && GUI.Button(new Rect(120, 200, 64,64), new GUIContent(bigHouseS, "CASAS GRANDES:\n\nConstrucción avanzada de casas. Generan mayores ingresos y permite que personas, que tengan el poder adquisitivo, vivan en la ciudad.\n\nCosto: 500\n\nTurnos: 4\n\nDa: 100 dólares por venta\n-3 Felicidad\nCapacidad: 25"))){
					//if(mainLog.GetComponent<GameScore>().canBigHouse && GUI.Button(new Rect(120, 200, 64,64), new GUIContent(bigHouseS, "BIG HOUSES:\n\nConstruction of luxury housing. Generates better income, allowing high-class to live in the area.\n\nCost: 500\n\nTurns: 4\n\nGives: 100 money per sale\n-3 Happiness\nCapacity: 25"))){
						audio.PlayOneShot(click, 0.5f);
					}
				}
				else{
					if(mainLog.GetComponent<GameScore>().canBigHouse && GUI.Button(new Rect(120, 200, 64,64), new GUIContent(bigHouse, "CASAS GRANDES:\n\nConstrucción avanzada de casas. Generan mayores ingresos y permite que personas, que tengan el poder adquisitivo, vivan en la ciudad.\n\nCosto: 500\n\nTurnos: 4\n\nDa: 100 dólares por venta\n-3 Felicidad\nCapacidad: 25"))){
						hammerGrid = 2;
						turns = 4;
						capBig = 25;
						happyModifierNow = -3.0f;
						cost = -500;
						audio.PlayOneShot(click, 0.5f);
					}
				}


				if(hammerGrid == 3){
					if(mainLog.GetComponent<GameScore>().canFarm && GUI.Button(new Rect(210, 200, 64,64), new GUIContent(farmS, "GRANJA:\n\nConstrucción básica para el suplemento de comida. Sube el índice de felicidad de la región.\n\nCosto: 200\n\nTurnos: 2\n\nDa: +2 Felicidad"))){
					//if(mainLog.GetComponent<GameScore>().canFarm && GUI.Button(new Rect(210, 200, 64,64), new GUIContent(farmS, "FARM:\n\nBasic construction for supplying food. Raises the happiness level of the region.\n\nCost: 200\n\nTurns: 2\n\nGives: +2 Happiness"))){
						audio.PlayOneShot(click, 0.5f);
					}
				}
				else{
					if(mainLog.GetComponent<GameScore>().canFarm && GUI.Button(new Rect(210, 200, 64,64), new GUIContent(farm, "GRANJA:\n\nConstrucción básica para el suplemento de comida. Sube el índice de felicidad de la región.\n\nCosto: 200\n\nTurnos: 2\n\nDa: +2 Felicidad"))){
						hammerGrid = 3;
						turns = 2;
						happyModifier = 2;
						cost = -200;
						audio.PlayOneShot(click, 0.5f);
					}
				}


				if(hammerGrid == 4){
					if(mainLog.GetComponent<GameScore>().canShop && GUI.Button(new Rect(30, 300, 64,64), new GUIContent(shopS, "SUPERMERCADO:\n\nConstrucción avanzada para el suplemento de comida. Sube el índice de felicidad de la región.\n\nCosto: 250\n\nTurnos: 5\n\nDa: +6 Felicidad\n\nRequiere 2 Granjas por cada Supermercado."))){
					//if(mainLog.GetComponent<GameScore>().canShop && GUI.Button(new Rect(30, 300, 64,64), new GUIContent(shopS, "SUPERMARKET:\n\nAdvance construction for supplying food on the region, raising happiness.\n\nCost: 250\n\nTurns: 5\n\nGives: +6 Happiness\n\n*Requires 2 Farms for each Supermarket*"))){
						audio.PlayOneShot(click, 0.5f);
					}
				}
				else{
					if((Mathf.Floor(mainLog.GetComponent<GameScore>().farmCount/2) > mainLog.GetComponent<GameScore>().shopCount) && mainLog.GetComponent<GameScore>().canShop && GUI.Button(new Rect(30, 300, 64,64), new GUIContent(shop, "SUPERMERCADO:\n\nConstrucción avanzada para el suplemento de comida. Sube el índice de felicidad de la región.\n\nCosto: 250\n\nTurnos: 5\n\nDa: +6 Felicidad\n\nRequiere 2 Granjas por cada Supermercado."))){
						//mainLog.GetComponent<GameScore>().shopCount++;
						hammerGrid = 4;
						turns = 5;
						happyModifier = 6;
						cost = -250;
						audio.PlayOneShot(click, 0.5f);
						}
					}


				if(hammerGrid == 5){
					if(mainLog.GetComponent<GameScore>().canGreen && GUI.Button(new Rect(120, 300, 64,64), new GUIContent(leafHouseS, "EDIFICIO VERDE:\n\nEdificio gubernamental y communitario que se dedica en la protección de la naturaleza. Sube el índice de naturaleza de la región.\n\nCosto: 400\n\nTurnos: 4\n\nDa: +4 Naturaleza"))){
					//if(mainLog.GetComponent<GameScore>().canGreen && GUI.Button(new Rect(120, 300, 64,64), new GUIContent(leafHouseS, "GREEN HOUSE:\n\nGovernment and community building dedicated to the cleaning and protection of the nature Raises the nature index of the region.\n\nCost: 400\n\nTurns: 4\n\nGives: +4 Nature\n\n*Allows the Cleaning and Protection of green areas*"))){
						audio.PlayOneShot(click, 0.5f);
					}
				}
				else{
					if(mainLog.GetComponent<GameScore>().canGreen && GUI.Button(new Rect(120, 300, 64,64), new GUIContent(leafHouse, "EDIFICIO VERDE:\n\nEdificio gubernamental y communitario que se dedica en la protección de la naturaleza. Sube el índice de naturaleza de la región.\n\nCosto: 400\n\nTurnos: 4\n\nDa: +4 Naturaleza"))){
						hammerGrid = 5;
						turns = 4;
						natureModifier = 4;
						cost = -400;
						audio.PlayOneShot(click, 0.5f);
					}
				}

				if(hammerGrid == 6){
					if(mainLog.GetComponent<GameScore>().canMovie && GUI.Button(new Rect(210, 300, 64,64), new GUIContent(movieS, "CINE:\n\nEdificio recreativo para los residentes de la ciudad. Sube el índice de felicidad de la región.\n\nCosto: 300\n\nTurnos: 3\n\nDa: +3 Felicidad"))){
					//if(mainLog.GetComponent<GameScore>().canMovie && GUI.Button(new Rect(210, 300, 64,64), new GUIContent(movieS, "MOVIE THEATER:\n\nRecreational building for the residents of the city. Reaises the happiness of the region.\n\nCost: 300\n\nTurns: 3\n\nGives: +3 Happiness"))){
						audio.PlayOneShot(click, 0.5f);
					}
				}
				else{
					if(mainLog.GetComponent<GameScore>().canMovie && GUI.Button(new Rect(210, 300, 64,64), new GUIContent(movie, "CINE:\n\nEdificio recreativo para los residentes de la ciudad. Sube el índice de felicidad de la región.\n\nCosto: 300\n\nTurnos: 3\n\nDa: +3 Felicidad"))){
						hammerGrid = 6;
						turns = 3;
						happyModifier = 3;
						cost = -300;
						audio.PlayOneShot(click, 0.5f);
					}
				}

				break;
			}

			if((leafGrid > 0 || axeGrid > 0 || hammerGrid > 0) && (mainLog.GetComponent<GameScore>().money + cost) >= 0){

				if(GUI.Button(new Rect(60, 400, 70, 30), "Aceptar")){
					audio.PlayOneShot(click, 0.5f);
					//DO COMMIT LOGIC HERE

					if(hammerGrid==4){
						mainLog.GetComponent<GameScore>().shopCount++;
					}

					finCons = mainLog.GetComponent<Watch>().currentTurn + turns;
					//Nature modifier now goes here
					//if(natureModifierNow > 0){
					mainLog.GetComponent<GameScore>().nature += natureModifierNow;

					//if(happyModifierNow > 0){
					mainLog.GetComponent<GameScore>().happy += happyModifierNow;

					mainLog.GetComponent<GameScore>().money += cost;

					if(leafGrid > 0){
						//leafChild = leaf;
						leafChild = Instantiate(leaf, transform.position+transform.up, transform.rotation) as GameObject;
						leafChild.transform.parent = this.gameObject.transform;
						//canBeProtected = true;
						audio.PlayOneShot(leafSFX);
						//leafChild.transform.position.x = leaf.transform.position.x + 0.8f;
					}

					if(axeGrid > 0){
						axeChild = Instantiate(axe, transform.position+transform.up, transform.rotation) as GameObject;
						axeChild.transform.parent = this.gameObject.transform;
						audio.PlayOneShot(axeSFX);
					}

					if(hammerGrid > 0){
						hammerChild = Instantiate(hammer, transform.position+transform.up, transform.rotation) as GameObject;
						hammerChild.transform.parent = this.gameObject.transform;
						audio.PlayOneShot(hammerSFX);
					}

					mainLog.GetComponent<ControlCheck>().haveSelected = false;
					mainLog.GetComponent<Watch>().isCounting = true; //Time continues
					lockTouch = false;
					startGUI = false;
					isBuilding = true;

				}

			}

			///////////////FONDOS INSUFICIENTES GOES HERE//////////////////////
			if((mainLog.GetComponent<GameScore>().money + cost) < 0)
			{
				GUI.Label(new Rect(40,405, 80,20), "Dinero insuficiente...", insuficiente);
			}

			if(GUI.Button(new Rect (180, 400, 70, 30), "Cancelar") || Input.GetKey(KeyCode.Escape)){


				audio.PlayOneShot(click, 0.5f);
				mainLog.GetComponent<ControlCheck>().haveSelected = false;
				mainLog.GetComponent<Watch>().isCounting = true; //Time continues
				lockTouch = false;
				startGUI = false;
			}

			GUI.EndGroup();

		}

		GUI.Box(new Rect (650, Event.current.mousePosition.y - 50, 200, 300), GUI.tooltip, tooltipStyle); //THIS IS WHERE THE TOOLTIP IS CALLED UPON

	}

	public void InstantiateAfterAWhile (GameObject go, Vector3 p, Quaternion r, float t) {

		ts += Time.deltaTime;
		//Debug.Log ("Building...");

		if (ts >= t) {
			go = Instantiate(go, p, r) as GameObject;
			go.transform.parent = this.gameObject.transform;
			//isBuilding = false;
			letsBuild = false;
			ts = 0;
			//Debug.Log("Built!");
			//ts = 0;
		}

		//buildChild = Instantiate(relleno, new Vector3(daddy.x, -0.2f, daddy.z), Quaternion.Euler(270,0,0)) as GameObject;
		//buildChild.transform.parent = this.gameObject.transform;
	}

	//RESET ALL RELEVANT VALUES TO AVOID ISSUES
	public void ResetValues(){
		leafGrid = 0;
		axeGrid = 0;
		hammerGrid = 0;
		happyModifier = 0;
		qualityModifier = 0;
		natureModifier = 0;
		natureModifierNow = 0;
		happyModifierNow = 0;
		cost = 0;
		capBig = 0;
		capSmall = 0;
	}

	//LOGIC WHEN THE MOUSE ENTERS AND TOUCHED THE BOX COLLIDER
	void OnMouseEnter(){

		if (mainLog.GetComponent<ControlCheck> ().haveSelected == false) {
			isTouch = true;
		}

	}

	void OnMouseExit(){

		isTouch = false;

	}

}
