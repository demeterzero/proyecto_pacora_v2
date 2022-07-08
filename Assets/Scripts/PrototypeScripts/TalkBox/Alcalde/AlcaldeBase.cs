using UnityEngine;
using System.Collections;

public class AlcaldeBase : MonoBehaviour {

	public Texture wallpaper, portrait;
	public GUIStyle name, message, button;
	public GameObject mainLog;
	public AudioClip SFX;
	public AudioSource a;
	public int whichTalk;
	public string messagecontent = "";
	
	// Use this for initialization
	void Start () {
		mainLog = GameObject.Find ("MainGameLogic");
		mainLog.GetComponent<ControlCheck> ().haveSelected = true;
		a = GetComponent<AudioSource> ();
		a.PlayOneShot (SFX);


	}
	
	// Update is called once per frame
	void Update () {

		mainLog.GetComponent<ControlCheck> ().haveSelected = true;

		switch(whichTalk){

		case 1:
			messagecontent = "Ha sido exactamente un año desde que comenzó este proyecto, y francamente, se está viendo fantástico. Me alegro de haberte escogido como dirigente de este megaproyecto - sigue así como andas, de seguro vendrá un futuro muy bueno para todos. \n\nPor cierto, espero que te estés llevando bien con Camila. Sé que es muy estricta -es parte de su personalidad, pero tiene buenas intenciones para todos; por eso los puse juntos en esta misión.";
			break;

		case 2:
			messagecontent = "Ha sido exactamente un año desde que comenzó este proyecto, y francamente, se está viendo fantástico. Me alegro de haberte escogido como dirigente de este megaproyecto - sigue así como andas, de seguro vendrá un futuro muy bueno para todos. \n\nPor cierto, espero que te estés llevando bien con Camila. Sé que es muy estricta -es parte de su personalidad, pero tiene buenas intenciones para todos; por eso los puse juntos en esta misión.";
			break;

		case 3:
			messagecontent = "Como pasa el tiempo, ¿no crees? A estas alturas, espero que puedas culminar este mega proyecto - de otro modo, no podremos proveerle de forma correcta al pueblo panameño. Asegúrate de dejar las cosas de una forma en que las personas y los humedales puedan coexistir, de otro modo, firmemente creo que el futuro de Panamá se perderá porque usamos la flora y fauna, que se supone que debemos de cuidar, de una forma irresponsable. \n\n Tengo fe en tus habilidades, amigo.";
			break;
		
		}

	}
	
	void OnGUI(){
		
		GUI.BeginGroup (new Rect (Screen.width*0.075f, Screen.height*0.075f, Screen.width * 7/8, Screen.height * 7/8));
		
		//GUI.Box (new Rect (0, 0, Screen.width * 7/8, Screen.height * 7/8), ""); USED TO VISUALIZE BORDERS
		GUI.DrawTexture (new Rect (0, 0, Screen.width * 7 / 8, Screen.height * 7 / 8), wallpaper, ScaleMode.StretchToFill, true, 1.0f); //Stretches wallpaper
		
		GUI.DrawTexture (new Rect (35, 35, 250, 350), portrait); //Portrait of the character
		
		GUI.Label (new Rect (320, 60, 80, 100), "Alcalde", name);
		
		GUI.Label (new Rect (320, 150, 475, 300), messagecontent, message);
		
		if (GUI.Button (new Rect (450, 450, 90, 40), "Ok", button)) {
			
			//Logic starts here
			mainLog.GetComponent<ControlCheck> ().haveSelected = false;
			Destroy(this.gameObject);
			
		}
		
		GUI.EndGroup ();
		
	}
	
}
