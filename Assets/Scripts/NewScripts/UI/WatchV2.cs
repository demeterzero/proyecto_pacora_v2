using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WatchV2 : MonoBehaviour {

	public float timer = 30.0f, rotationAngle = 0;
	public bool isCounting = false, nextTurn = false, rollScore = false;
	public int currentTurn = 1, countMonth, year;
	public AudioClip turnSFX;
	public AudioSource audio;
	public string month;
	public GameObject mc, cam, baseClock, watchHandle, textObj, nextButton;

	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();
		mc = GameObject.FindGameObjectWithTag ("MainCamera");

		countMonth = 7;
		year = 2030;

	}

	// Update is called once per frame
	void Update () {

		textObj.GetComponent<Text> ().text = "\nAño: " + year + "\n\nMes: " + month;

		if (mc.GetComponent<CameraMovement>().isSelect) {
			isCounting = false;
		} else {
			isCounting = true;
		}


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

			timer -= (Time.deltaTime);

			rotationAngle = timer*12;

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

		if (!isCounting) {

			nextButton.SetActive (false);

		} else {
			nextButton.SetActive (true);
		}

		watchHandle.transform.eulerAngles = new Vector3 (0, 0, rotationAngle);

		//Disable UI
		if (cam.GetComponent<CameraMovement> ().isSelect) {
			watchHandle.SetActive (false);
			textObj.SetActive (false);
			nextButton.SetActive(false);
			baseClock.SetActive (false);
		}
		else if(!cam.GetComponent<CameraMovement> ().isSelect){
			watchHandle.SetActive (true);
			textObj.SetActive (true);
			nextButton.SetActive(true);
			baseClock.SetActive (true);
		}

	}


	//Function for when the NextTurn button is pressed
	public void NextTurn(){

		nextTurn = true;

	}

}
