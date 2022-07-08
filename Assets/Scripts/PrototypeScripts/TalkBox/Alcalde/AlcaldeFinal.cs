﻿using UnityEngine;
using System.Collections;

public class AlcaldeFinal : MonoBehaviour {
	
	public Texture wallpaper, portrait;
	public GameObject nextmessage;
	public GUIStyle name, message, button;
	public GameObject mainLog;
	public AudioClip SFX;
	public AudioSource a;
	private string messagecontent = "Hoy finaliza la construcción del megaproyecto Nueva Pacora - esto era bosque tras bosque, pero con tu ayuda, hemos construido una ciudad bella y con mucha vida - espero que, de igual forma, hayas podido asegurar el futuro de la naturaleza cercana, ya que la protección del humedal y su naturaleza es importante. \n\nA todo caso, revisemos tus resultados de todos estos años,  ¿te parece?";

	// Use this for initialization
	void Start () {
		mainLog = GameObject.Find ("MainGameLogic");
		mainLog.GetComponent<ControlCheck> ().haveSelected = true;
		a = GetComponent<AudioSource> ();
		a.PlayOneShot (SFX);
		mainLog.GetComponent<GameScore> ().showGUI = false;
		mainLog.GetComponent<MusicLogic> ().moveGUI = true;
		mainLog.GetComponent<Watch> ().showGUItime = false;
		mainLog.GetComponent<ShowDate> ().showDate = false;
	}
	
	// Update is called once per frame
	void Update () {
		messagecontent = "Hoy finaliza la construcción del megaproyecto Nueva Pacora - esto era bosque tras bosque, pero con tu ayuda, hemos construido una ciudad bella y con mucha vida - espero que, de igual forma, hayas podido asegurar el futuro de la naturaleza cercana, ya que la protección del humedal y su naturaleza es importante. \n\nA todo caso, revisemos tus resultados de todos estos años,  ¿te parece?";
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