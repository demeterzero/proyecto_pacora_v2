using UnityEngine;
using System.Collections;

public class InstruccionesScrip : MonoBehaviour {
	
	public Texture wallpaper, portrait;
	public GameObject nextmessage;
	public ScriptableObject script;
	public GUIStyle name, message, button;
	public GameObject mainLog;
	private string messagecontent = "Usa las teclas W, A, S y D para mover la cámara.\nUsa el clic izquierdo de tu ratón para escoger un objeto - solo los objetos que cambian de color o tono a amarillo son interactuables. \n\nConstruye diferentes tipos de edificios para aumentar el índice de felicidad de la población, el cual afecta las ventas de las casas. Recuerda echarle un ojo al índice de la naturaleza de igual forma. \nExisten varios tipos de edificios por construir, y cada uno da diferentes resultados - construye hasta que tengas todos los edificios accesibles. \nLa tala de manglares baja el índice de la naturaleza bastante - ten en cuenta esto al expandir la ciudad.";

	// Use this for initialization
	void Start () {
		mainLog = GameObject.Find ("MainGameLogic");
		mainLog.GetComponent<ControlCheck> ().haveSelected = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
		
		GUI.BeginGroup (new Rect (Screen.width*0.075f, Screen.height*0.075f, Screen.width * 7/8, Screen.height * 7/8));
		
		//GUI.Box (new Rect (0, 0, Screen.width * 7/8, Screen.height * 7/8), ""); USED TO VISUALIZE BORDERS
		GUI.DrawTexture (new Rect (0, 0, Screen.width * 7 / 8, Screen.height * 7 / 8), wallpaper, ScaleMode.StretchToFill, true, 1.0f); //Stretches wallpaper
		
		//GUI.DrawTexture (new Rect (100, 35, 400, 200), portrait, ScaleMode.StretchToFill, true, 1.0f); //Portrait of the character
		
		GUI.Label (new Rect (35, 60, 160, 80), "Instrucctions", name);
		
		GUI.Label (new Rect (40, 150, 775, 300), messagecontent, message);
		
		if (GUI.Button (new Rect (450, 450, 90, 40), "Ok!", button)) {
			
			//Logic starts here
			
			mainLog.GetComponent<ControlCheck> ().haveSelected = false;
			Instantiate(nextmessage);
			
			Destroy(this.gameObject);
			
		}
		
		GUI.EndGroup ();
		
	}
	
}