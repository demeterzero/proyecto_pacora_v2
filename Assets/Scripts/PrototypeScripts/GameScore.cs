using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

	public int smallHouse=0, bigHouse=0, smallHouseMax = 0, bigHouseMax = 0, money=0, moneyScore=0, houseCount=0, houseBigCount=0, farmCount=0, shopCount=0, movieCount=0, greenCount=0;
	public float nature=0, happy=0, smallHouseModifier = 0, bigHouseModifier = 0, smallHouseScore=0, bigHouseScore=0;
	public Texture background, smallPic, bigPic, happyPic, leafPic, dollaPic;
	public GUIStyle arrow, textStyleLeft, textStyleRight, textStyleCenter;
	public bool canBigHouse = false, canFarm = false, canShop = false, canGreen = false, canMovie = false, canCleanCity = false, showGUI = true;


	// Use this for initialization
	void Start () {

		nature = 35.0f;
		money = 2000;
		moneyScore = 2000;
		//quality = 40.0f;
		happy = 30.0f;

		Screen.SetResolution (960, 600, false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (GetComponentInParent<Watch> ().rollScore) {
			
			if(smallHouseMax > 0){
				
				//smallHouseModifier = Mathf.Floor(1-((mainLog.GetComponent<GameScore> ().smallHouse)/(3*mainLog.GetComponent<GameScore> ().smallHouseMax)));
				
				smallHouseScore = Mathf.Floor (((100 * houseCount * (1 - smallHouseModifier)) / 4) * (nature / 100) * (happy / 100))*2f;
				
				if ((smallHouse+smallHouseScore) > smallHouseMax) {

					if(smallHouseMax>=smallHouse){
						money += Mathf.RoundToInt((smallHouseMax-smallHouse)*15);
						moneyScore += Mathf.RoundToInt((smallHouseMax-smallHouse)*15);
					}
					smallHouse = smallHouseMax;
				}else{
					money += Mathf.RoundToInt(smallHouseScore*15);
					moneyScore += Mathf.RoundToInt(smallHouseScore*15);
				}

				if(smallHouse < smallHouseMax){
					smallHouse += Mathf.RoundToInt(smallHouseScore);
				}else{
					smallHouse = smallHouseMax;
				}
				
			}
			
			if(bigHouseMax > 0){
				
				//bigHouseModifier = Mathf.Floor(1-((mainLog.GetComponent<GameScore> ().bigHouse)/(3*mainLog.GetComponent<GameScore> ().bigHouseMax)));
				
				bigHouseScore = Mathf.Floor (((100 * houseBigCount * (1 - bigHouseModifier)) / 4) * (nature / 100) * (happy / 100))*2f;
				
				if ((bigHouse+bigHouseScore) > bigHouseMax) {

					if(bigHouseMax>=bigHouse){
						money += Mathf.RoundToInt((bigHouseMax-bigHouse)*100);
						moneyScore += Mathf.RoundToInt((bigHouseMax-bigHouse)*100);
					}
					bigHouse = bigHouseMax;
				}else{
					money += Mathf.RoundToInt(bigHouseScore * 100);
					moneyScore += Mathf.RoundToInt(bigHouseScore * 100);
				}
				
				if(bigHouse < bigHouseMax){
					bigHouse += Mathf.RoundToInt(bigHouseScore);
				}else{
					bigHouse = bigHouseMax;
				}
				
			}
			
			GetComponentInParent<Watch> ().rollScore = false;
			
		}

		if (nature > 100) {
			nature = 100;
		}

		if (nature < 0) {
			nature = 0;
		}

		if (happy > 100) {
			happy = 100;
		}

		if (happy < 0) {
			happy = 0;
		}

	}

	void OnGUI (){

		if (showGUI) {

			GUI.BeginGroup (new Rect (660, 350, 300, 250));

			GUI.depth = 10;

			GUI.DrawTexture (new Rect (0, 0, 300, 250), background);

			GUI.DrawTexture (new Rect (30, 20, 32, 32), smallPic);

			GUI.Label (new Rect (100, 20, 50, 30), smallHouse.ToString (), textStyleLeft);
			GUI.Label (new Rect (160, 20, 20, 30), "/", textStyleCenter);
			GUI.Label (new Rect (190, 20, 50, 30), smallHouseMax.ToString (), textStyleRight);

			GUI.DrawTexture (new Rect (30, 80, 32, 32), bigPic);

			GUI.Label (new Rect (100, 80, 50, 30), bigHouse.ToString (), textStyleLeft);
			GUI.Label (new Rect (160, 80, 20, 30), "/", textStyleCenter);
			GUI.Label (new Rect (190, 80, 50, 30), bigHouseMax.ToString (), textStyleRight);

			GUI.DrawTexture (new Rect (30, 140, 32, 32), happyPic);

			GUI.Label (new Rect (100, 140, 20, 30), happy.ToString () + "%", textStyleCenter);

			GUI.DrawTexture (new Rect (160, 140, 32, 32), leafPic);

			GUI.Label (new Rect (230, 140, 20, 30), nature.ToString () + "%", textStyleCenter);

			GUI.DrawTexture (new Rect (30, 200, 32, 32), dollaPic);

			GUI.Label (new Rect (70, 200, 150, 30), money.ToString (), textStyleCenter);

			if (GetComponentInParent<ControlCheck> ().haveSelected == false) {
				if (GUI.Button (new Rect (230, 180, 64, 64), "", arrow)) {
					//nextTurn = true;
					GetComponentInParent<Watch> ().nextTurn = true;
				}
			}

			GUI.EndGroup ();

		}

	}

}
