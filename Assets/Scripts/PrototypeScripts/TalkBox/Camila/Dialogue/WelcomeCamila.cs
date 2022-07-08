using UnityEngine;
using System.Collections;

public class WelcomeCamila : MonoBehaviour {

	public Texture wallpaper, portrait;
	//public GameObject nextmessage, foundgo;
	public GUIStyle name, message, button;
	public GameObject mainLog;
	public AudioClip SFX;
	public AudioSource a;
	public string messagecontent;
	
	// Use this for initialization
	void Start () {
		mainLog = GameObject.Find ("MainGameLogic");
		mainLog.GetComponent<ControlCheck> ().haveSelected = true;
		messagecontent = "¡Qué tal, Inversionista! Mi nombre es Camila, y soy la mano derecha del Alcalde de Panamá. \n\nEl proyecto “Nueva Pacora” es de gran importancia para nuestro país y su expansión. Pero es importante no solo suplir a los residentes con sus necesidades, sino proteger los mangles cercanos. Dado a que estamos comenzando, ¿por qué no mandamos a construir 2 casas? De esta forma, los residentes podrán comenzar a venir a Nueva Pacora poco a poco. \n\n *Construye 2 Casas Chicas*";
		a = GetComponent<AudioSource> ();
		a.PlayOneShot (SFX);
	}
	
	void OnGUI(){
		
		GUI.BeginGroup (new Rect (Screen.width*0.075f, Screen.height*0.075f, Screen.width * 7/8, Screen.height * 7/8));
		
		//GUI.Box (new Rect (0, 0, Screen.width * 7/8, Screen.height * 7/8), ""); USED TO VISUALIZE BORDERS
		GUI.DrawTexture (new Rect (0, 0, Screen.width * 7 / 8, Screen.height * 7 / 8), wallpaper, ScaleMode.StretchToFill, true, 1.0f); //Stretches wallpaper
		
		GUI.DrawTexture (new Rect (35, 35, 250, 350), portrait); //Portrait of the character
		
		GUI.Label (new Rect (320, 60, 80, 100), "Camila", name);
		
		GUI.Label (new Rect (320, 150, 475, 300), messagecontent, message);
		
		if (GUI.Button (new Rect (450, 450, 90, 40), "Ok", button)) {
			
			//Logic starts here
			//START GAME HERE!!!
			/*
			 * Instantiate(nextmessage);

			foundgo = GameObject.Find(nextmessage.name+"(Clone)");

			foundgo.gameObject.AddComponent<Test>();

			foundgo.GetComponent<CamilaBase>().messagecontent = foundgo.GetComponent<Test>().message;
			*/

			mainLog.GetComponent<ControlCheck> ().haveSelected = false;
			GameObject.Find("MainGameLogic").GetComponent<Watch>().isCounting = true;

			Destroy(this.gameObject);
			
		}
		
		GUI.EndGroup ();
		
	}
}