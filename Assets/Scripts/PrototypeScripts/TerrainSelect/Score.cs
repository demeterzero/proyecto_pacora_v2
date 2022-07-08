using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public float smallHouse = 0, bigHouse = 0, smallHouseModifier = 0, bigHouseModifier = 0;
	public GameObject mainLog;

	// Use this for initialization
	void Start () {
	
		mainLog = GameObject.Find ("MainGameLogic");

	}
	
	// Update is called once per frame
	void Update () {

		if (mainLog.GetComponent<Watch> ().rollScore) {

			if(mainLog.GetComponent<GameScore> ().smallHouseMax > 0){

				//smallHouseModifier = Mathf.Floor(1-((mainLog.GetComponent<GameScore> ().smallHouse)/(3*mainLog.GetComponent<GameScore> ().smallHouseMax)));

				smallHouse = Mathf.Floor (((100 * mainLog.GetComponent<GameScore> ().houseCount * (1 - smallHouseModifier)) / 4) * (mainLog.GetComponent<GameScore> ().nature / 100) * (mainLog.GetComponent<GameScore> ().happy / 100));

				if (smallHouse > mainLog.GetComponent<GameScore> ().smallHouseMax) {
					smallHouse += mainLog.GetComponent<GameScore> ().smallHouseMax;
				}

				mainLog.GetComponent<GameScore> ().smallHouse = Mathf.RoundToInt(smallHouse);

			}

			if(mainLog.GetComponent<GameScore> ().bigHouseMax > 0){

				//bigHouseModifier = Mathf.Floor(1-((mainLog.GetComponent<GameScore> ().bigHouse)/(3*mainLog.GetComponent<GameScore> ().bigHouseMax)));

				bigHouse = Mathf.Floor (((100 * mainLog.GetComponent<GameScore> ().houseBigCount * (1 - bigHouseModifier)) / 4) * (mainLog.GetComponent<GameScore> ().nature / 100) * (mainLog.GetComponent<GameScore> ().happy / 100));

				if (bigHouse > mainLog.GetComponent<GameScore> ().bigHouseMax) {
					smallHouse += mainLog.GetComponent<GameScore> ().bigHouseMax;
				}

				mainLog.GetComponent<GameScore> ().bigHouse = Mathf.RoundToInt(bigHouse);

			}

			mainLog.GetComponent<Watch> ().rollScore = false;

		}

	}
}
