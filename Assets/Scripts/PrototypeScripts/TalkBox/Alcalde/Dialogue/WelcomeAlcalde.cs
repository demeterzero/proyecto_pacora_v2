using UnityEngine;
using System.Collections;

public class WelcomeAlcalde : MonoBehaviour {

	public Texture wallpaper, portrait;
	public GameObject nextmessage;
	public GUIStyle name, message, button;
	public GameObject mainLog;
	public AudioClip SFX;
	public AudioSource a;
	private string messagecontent = "¡Hola compañero! ¿Te gusta tu nueva oficina? Tendrás que adaptarte a este cambio - eres el único en el cual puedo confiar para hacer esta misión.\n\nTe he puesto con mi secretaria de confianza, Camila, para que te ayude a construir este nuevo megaproyecto. Es importante terminar este proyecto en los siguientes 4 años; espero resultados magníficos de tu parte, amigo.";
	// Use this for initialization
	void Start () {
		mainLog = GameObject.Find ("MainGameLogic");
		mainLog.GetComponent<ControlCheck> ().haveSelected = true;
		a = GetComponent<AudioSource> ();
		a.PlayOneShot (SFX);
	}
	
	// Update is called once per frame
	void Update () {
		
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
			Instantiate(nextmessage);

			Destroy(this.gameObject);
			
		}
		
		GUI.EndGroup ();
		
	}
}