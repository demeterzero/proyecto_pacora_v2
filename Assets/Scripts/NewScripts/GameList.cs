using UnityEngine;
using System.Collections.Generic;

public class GameList : MonoBehaviour {

	public int newPeople = 0, curPeople, maxPeople, houseOffset = 0, curWork, maxWork, workOffset, baseOffset = 0;
	public int happy, water, logistica, naturaleza, money, comeMult; 

	public List<GameObject> house = new List<GameObject>();
	public List<GameObject> work = new List<GameObject>();
	public List<GameObject> build = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Logic to add things when turn is over
		if (GetComponent<WatchV2> ().rollScore) {

			maxWork = 0;
			maxPeople = 0;

			//Do the Building List first

			for (int i = 0; i < build.Count; i++) {

				if (build [i].GetComponent<BuildLogic>().curTurn < build [i].GetComponent<BuildLogic>().maxTurn)
					build [i].GetComponent<BuildLogic>().curTurn++;

			}

			//Formula for new people arriving Second

			//Resets multiplier for every calculation
			comeMult = 0;

			for (int i = 0; i < house.Count && newPeople != 0; i++) {

				if (house [i].GetComponent<HousingLogic> ().maxCap != house [i].GetComponent<HousingLogic> ().curCap)
					comeMult++;

			}

			newPeople = Mathf.RoundToInt ((happy + water + logistica + naturaleza) / 400) * comeMult * 25;

			//Do the House List Third with Money

			for (int i = 0; i < house.Count && newPeople != 0; i++) {

				maxPeople += house [i].GetComponent<HousingLogic> ().maxCap;

				//print ("I am in!");

				//If there is still space
				if (house [i].GetComponent<HousingLogic> ().curCap < house [i].GetComponent<HousingLogic> ().maxCap) {

					//If the new people excede the cap
					if (house [i].GetComponent<HousingLogic> ().curCap + newPeople > house [i].GetComponent<HousingLogic> ().maxCap) {

						curPeople += house [i].GetComponent<HousingLogic> ().maxCap - house [i].GetComponent<HousingLogic> ().curCap;

						//////////////////////MONEY PART///////////////////////////

						switch (house [i].GetComponent<HousingLogic> ().whichHouse) {

						case 1:

							money += 4 * (house [i].GetComponent<HousingLogic> ().maxCap - house [i].GetComponent<HousingLogic> ().curCap);

							break;

						case 2:

							money += 8 * (house [i].GetComponent<HousingLogic> ().maxCap - house [i].GetComponent<HousingLogic> ().curCap);

							break;

						case 3:

							money += 4 * (house [i].GetComponent<HousingLogic> ().maxCap - house [i].GetComponent<HousingLogic> ().curCap);

							break;

						}
							
						//////////////////////MONEY PART///////////////////////////

						newPeople = (house [i].GetComponent<HousingLogic> ().curCap - house [i].GetComponent<HousingLogic> ().maxCap) + newPeople;

						house [i].GetComponent<HousingLogic> ().curCap = house [i].GetComponent<HousingLogic> ().maxCap;

						//If the new people do NOT excede the cap of the current house
					} else {

						curPeople += newPeople;

						house [i].GetComponent<HousingLogic> ().curCap += newPeople;

						//////////////////////MONEY PART///////////////////////////

						switch (house [i].GetComponent<HousingLogic> ().whichHouse) {

						case 1:

							money += 4 * newPeople;

							break;

						case 2:

							money += 8 * newPeople;

							break;

						case 3:

							money += 4 * newPeople;

							break;

						}

						//////////////////////MONEY PART///////////////////////////

						newPeople = 0;

					}

				}

				/*else if(house [i].GetComponent<HousingLogic> ().curCap == house [i].GetComponent<HousingLogic> ().maxCap && newPeople != 0){
					baseOffset++;
				}*/

			}


			/*
			//Do offset AFTER for sequence to add offset
			if (baseOffset > 0) {
				houseOffset += baseOffset;
				baseOffset = 0;
			}*/


			//Do the Work List Last

			newPeople = curPeople - curWork;

			for (int i = 0; i < work.Count; i++) {

				maxWork += work [i].GetComponent<HousingLogic> ().maxCap;

				if (work [i].GetComponent<HousingLogic> ().curCap < work [i].GetComponent<HousingLogic> ().maxCap) {

					//If the new people excede the cap
					if (work [i].GetComponent<HousingLogic> ().curCap + newPeople > work [i].GetComponent<HousingLogic> ().maxCap) {

						curWork += work [i].GetComponent<HousingLogic> ().maxCap - work [i].GetComponent<HousingLogic> ().curCap;

						newPeople = (work [i].GetComponent<HousingLogic> ().curCap + newPeople) - work [i].GetComponent<HousingLogic> ().maxCap;

						work [i].GetComponent<HousingLogic> ().curCap = work [i].GetComponent<HousingLogic> ().maxCap;

						//If the new people do NOT excede the cap of the current house
					} else {

						curWork += newPeople;

						house [i].GetComponent<HousingLogic> ().curCap += newPeople;

						newPeople = 0;

					}

				}

			}

			//Finish logic, set variable as false to reset timer
			GetComponent<WatchV2> ().rollScore = false;

		}
	}
}