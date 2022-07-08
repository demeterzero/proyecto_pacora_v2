using UnityEngine;
using System.Collections;

public class Watch : MonoBehaviour {

	public Texture watch, handle;
	public float timer = 30.0f, multiplier = 1.0f, rotationAngle = 0;
	public bool isCounting = false, nextTurn = false, rollScore = false, showGUItime = true;
	public int currentTurn = 1, countMonth, year;
	public AudioClip turnSFX;
	public AudioSource audio;
	public string month;
	public GUIStyle arrow;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();
	
		countMonth = 7;
		year = 2030;

	}
	
	// Update is called once per frame
	void Update () {

		/*
		if (GetComponentInParent<ControlCheck> ().haveSelected) {
			isCounting = false;
		} else {
			isCounting = true;
		}
		*/

		if (countMonth > 12) {
			countMonth-=12;
			year++;
		}

		switch (countMonth) {

		case 1:
			month = "Enero";
				break;

		case 2:
			month = "Febrero";
			break;

		case 3:
			month = "Marzo";
			break;

		case 4:
			month = "Abril";
			break;

		case 5:
			month = "Mayo";
			break;

		case 6:
			month = "Junio";
			break;

		case 7:
			month = "Julio";
			break;

		case 8:
			month = "Agosto";
			break;

		case 9:
			month = "Septiembre";
			break;

		case 10:
			month = "Octubre";
			break;

		case 11:
			month = "Noviembre";
			break;

		case 12:
			month = "Diciembre";
			break;

		}
	
		//IF THE GAME IS COUNTING
		if (isCounting) {

			timer -= (Time.deltaTime * multiplier);

			rotationAngle = timer*-12;

			//IF THE TIMER REACHES 0 OR PASSES 0
			if (timer <= 0 || nextTurn == true) {
				//timer = 0;
				audio.PlayOneShot(turnSFX);
				nextTurn = false;
				rotationAngle = 0;
				currentTurn++;
				timer = 30.0f;
				countMonth++;

				//Value to be read by other objects to run calculations
				rollScore = true;
			}
		}

	}

	void OnGUI(){


		/*if (GetComponentInParent<ControlCheck> ().haveSelected == false) {

			if (GUI.Button (new Rect (890, 530, 64, 64), "", arrow)) {
				nextTurn = true;
			}

		}*/


		//GUI.BeginGroup()
		if (showGUItime) {

			GUI.DrawTexture (new Rect (850, 10, 50, 50), watch);

			GUIUtility.RotateAroundPivot (rotationAngle, new Vector2 (875, 35)); //Texture size plus HALF on X and Y gives the exact center for pivot
			GUI.DrawTexture (new Rect (850, 10, 50, 50), handle);

		}

		//GUI.EndGroup ();

		//MONTH AND YEAR
		GUI.Label (new Rect (830, 80, 80, 20), month);
		GUI.Label (new Rect (900, 80, 40, 20), year.ToString());
	
	}
}
