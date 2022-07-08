using UnityEngine;
using System.Collections;

public class CamilaBase : MonoBehaviour {

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
			messagecontent = "Perfecto, con la construcción de estas casas, las personas comenzarán a mudarse a esta nueva ciudad. Es importante considerar que los valores de felicidad y estado ambiental afectan en la velocidad en la cual las personas emigran hacia esta ciudad, por ende, es importante tomar en cuenta estos factores. \n\n¿Porqué no seguimos expandiendo la ciudad? Para ello, le sugiero remover parte de los bosques, pero tenga en mente cuidar de los manglares cercanos.";
			break;

		case 2:
			messagecontent = "Ahora que nos hemos expandido, es importante considerar el desarrollo de la comida en la región - granjas. Es importante tener un suplemento local de comida, de esta forma los residentes pueden comer de forma correcta, y de la misma forma, sube el índice de felicidad en la región.  ¿Qué tal si construimos al menos 2 granjas? \n\n*Ahora se pueden construir Granjas*";
			mainLog.GetComponent<GameScore>().canFarm = true;
			break;

		case 3:
			messagecontent = "Los residentes han expresado su temor con respecto a la naturaleza, y específicamente en los humedales y sus manglares cercanos. Debido a esto (y la iniciativa de Kalito), he creado un plan para un edificio llamado 'Edificio Verde'. Con este edificio, podemos mejorar el estado de la naturaleza en general, y podemos cuidar mejor a los manglares cercanos. Recomiendo, con carácter de urgencia, construir esto. \n\n*Ahora se puede construir el Edificio Verde*";
			mainLog.GetComponent<GameScore>().canGreen = true;
			break;

		case 4:
			messagecontent = "¡Excelente! Con la construcción del Edificio Verde, se podrán ejecutar la limpieza de bosques y mangles, y de igual forma, su protección. Sr. Inversionista, es importante proteger los mangles - estos nos protegen de las olas del mar y tormentas. ¡Tenemos que ejecutar programas de protección de inmediato! \n\n*Ahora se pueden ejecutar acciones de Limpiar y Proteger los Bosques y Mangles*";
			//mainLog.GetComponent<GameScore>().canCleanCity = true;
			break;

		case 5:
			messagecontent = "Mire, Sr.  Inversionista, ¡aves playeras! Dado a la construcción del Edificio Verde y las actividades comunitarias de los bosques y manglares, estas aves están apareciendo hasta en Nueva Pacora. Esto es un buen indicador del estado de los humedales, ya que estas aves migran de un lado de las Américas hasta el otro, y usan esta área como reposo. Estoy segura que las organizaciones de Humedales Ramsar estarán felices con estos resultados, ya que el Humedal de Panamá se considera protegido por dicha organización de reconocimiento mundial.";
			break;

		}
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
			mainLog.GetComponent<ControlCheck> ().haveSelected = false;
			Destroy(this.gameObject);
			
		}
		
		GUI.EndGroup ();
		
	}
	
}
