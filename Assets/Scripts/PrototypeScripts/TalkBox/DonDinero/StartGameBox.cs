using UnityEngine;
using System.Collections;

public class StartGameBox : MonoBehaviour {

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

		switch (whichTalk) {

		case 1:
			messagecontent = "Saludos, caballero Inversionista. He notado que en Nueva Pacora, al tratar de comprar algo, se necesita viajar al mercado - para mí, ¡esto es inaceptable! ¿Cómo no puede ser que no existe algún tipo de supermercado que pueda proveer las necesidades básicas de sus ciudadanos? De igual forma, al proveer dicho servicio, este atrae sus propias ganancias a largo plazo - le sugiero, señor Inversionista, que construya estos supermercados, para el bien del pueblo. \n\n*Ahora se pueden construir Supermercados*";
			mainLog.GetComponent<GameScore>().canShop = true;
			break;

		case 2:
			messagecontent = "Perfecto, la construcción de un supermercado es ideal para la sostenibilidad de la sociedad - usted, señor Inversionista, ha hecho una gran cosa en el día de hoy. Estaré vigilando Nueva Pacora de una forma cuidadosa; estoy viendo que aquí existen oportunidades para expandir varios negocios, y usted, señor Inversionista, puede ganar mucho en el proceso. \n\n Estaremos en contacto.";
			break;

		case 3:
			messagecontent = "Para poder mudarme de forma correcta, es necesaria la construcción de acomodaciones apropiadas. De igual forma, mis compañeros del mismo rango social están interesados en lo que es Nueva Pacora, y estamos dispuestos a comprar viviendas en la región, si están a la altura de lo que necesitamos. ¿Qué le parece, señor Inversionista?¿Construimos un par de casas grandes? ¿Tal vez alguna de playa? \n\n*Ahora se pueden construir Casas Grandes*";
			mainLog.GetComponent<GameScore>().canBigHouse = true;
			break;

		case 4:
			messagecontent = "Señor Inversionista, encuentro inconcebible el hecho de que aun no existen muchas casas de buena calidad en Nueva Pacora - esto nos hace,  a mí y a mis compañeros, muy tristes. Tenemos grandes expectativas de Nueva Pacora para hacer negocios, pero sin las acomodaciones correctas, esto no podrá suceder. \n\nPorfavor señor Inversionista, considere esta oportunidad que se le presenta.";
			break;
		}
	}

	void OnGUI(){

		GUI.BeginGroup (new Rect (Screen.width*0.075f, Screen.height*0.075f, Screen.width * 7/8, Screen.height * 7/8));

		//GUI.Box (new Rect (0, 0, Screen.width * 7/8, Screen.height * 7/8), ""); USED TO VISUALIZE BORDERS
		GUI.DrawTexture (new Rect (0, 0, Screen.width * 7 / 8, Screen.height * 7 / 8), wallpaper, ScaleMode.StretchToFill, true, 1.0f); //Stretches wallpaper

		GUI.DrawTexture (new Rect (35, 35, 250, 350), portrait); //Portrait of the character

		GUI.Label (new Rect (320, 60, 80, 100), "Don Dinero", name);

		GUI.Label (new Rect (320, 150, 475, 300), messagecontent, message);

		if (GUI.Button (new Rect (450, 450, 90, 40), "Ok", button)) {

			//Logic starts here
			mainLog.GetComponent<ControlCheck> ().haveSelected = false;
			Destroy(this.gameObject);

		}

		GUI.EndGroup ();

	}

}
