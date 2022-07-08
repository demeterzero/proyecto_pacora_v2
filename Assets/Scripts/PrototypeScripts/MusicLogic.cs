using UnityEngine;
using System.Collections;

public class MusicLogic : MonoBehaviour {

	public int i;
	public AudioClip song1, song2, song3, song4, song5;
	public AudioSource a;
	public bool isPaused = false, moveGUI = false;
	public float guiOffset = 0;
	public GUIStyle buttonBlue, buttonGray;

	// Use this for initialization
	void Start () {

//		AudioClip[] clips = new AudioClip[5]{song1, song2, song3, song4, song5};

		a = GetComponent<AudioSource> ();
		//a.clip = clips[i];
		i = -1;

		//a.clip = song1;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (moveGUI) {
			guiOffset = -30.0f;
		}

		if (!a.isPlaying && !isPaused) {
			i++;
			if(i >4){
				i=0;	
			}

			switch(i){
			case 0:
				a.clip = song1;
				break;
			case 1:
				a.clip = song2;
				break;
			case 2:
				a.clip = song3;
				break;
			case 3:
				a.clip = song4;
				break;
			case 4:
				a.clip = song5;
				break;
			}

			a.Play ();
		}

		/*
		if(Input.GetKeyUp(KeyCode.M)){
			a.Stop();
			i++;
			if(i >4){
				i=0;	
			}

			switch(i){
			case 0:
				a.clip = song1;
				break;
			case 1:
				a.clip = song2;
				break;
			case 2:
				a.clip = song3;
				break;
			case 3:
				a.clip = song4;
				break;
			case 4:
				a.clip = song5;
				break;
			}

			a.Play ();
		}
		*/
	
	}

	void OnGUI(){

		if (!isPaused) {
			if (GUI.Button (new Rect (20, 520+guiOffset, 64, 64), "", buttonBlue)) {
				a.Stop ();
				isPaused = true;
			}
		}

		if (isPaused) {
			if (GUI.Button (new Rect (20, 520+guiOffset, 64, 64), "", buttonGray)) {

				isPaused = false;
			}
		}

		//GUI.Button(new Rect(60,540, 60,20)

	}

}
