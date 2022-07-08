using UnityEngine;
using System.Collections;

public class GameFinish : MonoBehaviour {

	public Texture wallpaper, portrait;
	public GameObject nextmessage;
	public ScriptableObject script;
	public GUIStyle name, message, button;
	public GameObject mainLog, creditScreen;
	private string messagecontent;
	//\n
	// Use this for initialization
	void Start () {
		mainLog = GameObject.Find ("MainGameLogic");
		mainLog.GetComponent<ControlCheck> ().haveSelected = true;
		messagecontent = "Cantidad de dinero recolectado: B/ " + mainLog.GetComponent<GameScore> ().moneyScore + "\nDinero usado: B/ " + (mainLog.GetComponent<GameScore> ().moneyScore - mainLog.GetComponent<GameScore> ().money) + "\nDinero Restante: B/ " + mainLog.GetComponent<GameScore> ().money + "\nCasas Chicas: " + mainLog.GetComponent<GameScore> ().smallHouse + " de " + mainLog.GetComponent<GameScore> ().smallHouseMax+" ocupadas.\nCasas grandes: "+mainLog.GetComponent<GameScore> ().bigHouse+" de "+mainLog.GetComponent<GameScore> ().bigHouseMax+" ocupadas.\nÍndice de Felicidad: "+mainLog.GetComponent<GameScore> ().happy+"%\nÍndice de Naturaleza: "+mainLog.GetComponent<GameScore> ().nature+"%";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){


			GUI.BeginGroup (new Rect (Screen.width * 0.075f, Screen.height * 0.075f, Screen.width * 7 / 8, Screen.height * 7 / 8));
		
			//GUI.Box (new Rect (0, 0, Screen.width * 7/8, Screen.height * 7/8), ""); USED TO VISUALIZE BORDERS
			GUI.DrawTexture (new Rect (0, 0, Screen.width * 7 / 8, Screen.height * 7 / 8), wallpaper, ScaleMode.StretchToFill, true, 1.0f); //Stretches wallpaper
		
			//GUI.DrawTexture (new Rect (100, 35, 400, 200), portrait, ScaleMode.StretchToFill, true, 1.0f); //Portrait of the character
		
			GUI.Label (new Rect (35, 60, 160, 80), "Estadísticas del Juego", name);
		
			GUI.Label (new Rect (40, 150, 775, 300), messagecontent, message);
		
			if (GUI.Button (new Rect (450, 450, 90, 40), "Créditos", button)) {
			
				//Logic starts here
				//credits = true;

				Instantiate(creditScreen);
				Destroy(this.gameObject);
			
			}
		
			GUI.EndGroup ();

		//if (credits) {

		}
		
	}
	

