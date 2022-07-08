using UnityEngine;
using System.Collections;

public class KalitoBase : MonoBehaviour {

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
			messagecontent = "¡Qué xopá! ¿Tú eres el man al que llaman “Inversionista”? Pilla, que vengo a decirte algo importante de parte de los residentes. A nosotros, los residentes de Nueva Pacora, nos importa el estado de los manglares y los bosques, entonces cuando mandes a cortar alguno, trata con cariño a la madre naturaleza. Es importante que haya árboles, de otro modo no caerá ni una gota de lluvia, ¡y se formará manso calor! \n\n’Tonces suave Inver; si no hay apuro, ¡corta los bosques como debe ser!";
			break;

		case 2:
			messagecontent = "¡Chaaa fren, la ciudad se 'ta viendo bien seria! Para ser franco Inver, cuando te vi, pensaba que eras otro de esos ladrones que solo vienen a enriquecer sus bolsillos, ¡pero 'toy viendo que tas serio con esto! Inver, si algo está mal en la ciudad, vendré a comunicártelo de inmediato - así evita problemas entre la administración y el pueblo. \n\nPero pa’ serte franco, me siento algo aburrido - tal vez venga con una idea y te ayude pronto - ¿sí o qué?";
			break;

		case 3:
			messagecontent = "¡Fren! La construcción de la ciudad ‘ta quedando fina, pero.. ¡'toy aburrido loco! Aparte de parkear con la banda, ¡no hay na'a que hacer en Nueva Pacora! Minimo, tengo que ir a la ciudad para ver una película seria. Y hablando de películas, vine con mi idea: ¡un cine! Serio Inver! No me mires con cara de loco, ¡estoy en serio! ¡Si construimos un par, este lugar se volvería más divertido para mí- digo, para todos!  ¡Ponle play a esas construcciones, Inver! \n\n*Ahora se pueden construir Cines*";
			mainLog.GetComponent<GameScore>().canMovie = true;
			break;

		case 4:
			messagecontent = "¡Hey, Inver! Los residentes de Nueva Pacora no están felices - ¡dicen que estas favoreciendo a la gente que tiene plata! No seas así Inver, a esa gente solo le interesa el dinero, pero nosotros, el pueblo panameño, necesitamos de personas como tú para formar un mejor futuro. \n\n Ayúdanos, Inver, dános mejor calidad de vida en Nueva Pacora. ¡Yo sé que tú puedes!";
			break;

		case 5:
			messagecontent = "¡Hey, Inver! ¡Los árboles de Nueva Pacora ‘tan casi muertos, loco! Nosotros tenemos que poner de nuestra parte, pero si tú no nos ayudas ni nos facilitas el proceso de limpiar y proteger los bosques y humedales de Panamá, estos no los vera ni mi hijo - ¡y el solo tiene 2 años! \n\n Vamos Inver, ayúdanos a ayudarte - protejamos de mejor forma los humedales y la madre naturaleza, fren.";
			break;

		case 6:
			messagecontent = "Waaa, ¡ta lloviendo Inver! Y ahora en la tarde 'ta haciendo manso fresco - vaya Inver, ¿viste? Si tratamos bien a la naturaleza, ella nos paga de vuelta con una tarde bien priti. De seguro mis frenes están gozando de esta tarde fresca, debería llegar y parkear con mi banda. ¡Tu tambien, Inver! Llégate, te presento a mis frenes, te invito la cena - es lo menos que puedo hacer para darte las gracias por cuidar bien de Nueva Pacora y su naturaleza.";
			break;
		}
	}
	
	void OnGUI(){
		
		GUI.BeginGroup (new Rect (Screen.width*0.075f, Screen.height*0.075f, Screen.width * 7/8, Screen.height * 7/8));
		
		//GUI.Box (new Rect (0, 0, Screen.width * 7/8, Screen.height * 7/8), ""); USED TO VISUALIZE BORDERS
		GUI.DrawTexture (new Rect (0, 0, Screen.width * 7 / 8, Screen.height * 7 / 8), wallpaper, ScaleMode.StretchToFill, true, 1.0f); //Stretches wallpaper
		
		GUI.DrawTexture (new Rect (35, 35, 250, 350), portrait); //Portrait of the character
		
		GUI.Label (new Rect (320, 60, 80, 100), "Kalito", name);
		
		GUI.Label (new Rect (320, 150, 475, 300), messagecontent, message);
		
		if (GUI.Button (new Rect (450, 450, 90, 40), "Ok", button)) {
			
			//Logic starts here
			mainLog.GetComponent<ControlCheck> ().haveSelected = false;
			Destroy(this.gameObject);
			
			
		}
		
		GUI.EndGroup ();
		
	}
	
}
