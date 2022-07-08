using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameStatsUI : MonoBehaviour {

	public GameObject people, work, nature, water, happy, car, money, mgl, cam;

	// Update is called once per frame
	void Update () {

		people.GetComponent<Text> ().text = mgl.GetComponent<GameList>().curPeople+" / "+mgl.GetComponent<GameList>().maxPeople;
		work.GetComponent<Text> ().text = mgl.GetComponent<GameList>().curWork+" / "+mgl.GetComponent<GameList>().maxWork;
		nature.GetComponent<Text> ().text = mgl.GetComponent<GameList>().naturaleza+"%";
		water.GetComponent<Text> ().text = mgl.GetComponent<GameList>().water+"%";
		happy.GetComponent<Text> ().text = mgl.GetComponent<GameList>().happy+"%";
		car.GetComponent<Text> ().text = mgl.GetComponent<GameList>().logistica+"%";
		money.GetComponent<Text> ().text = "$"+mgl.GetComponent<GameList>().money;

		if (cam.GetComponent<CameraMovement> ().isSelect) {
			foreach (Transform child in transform) {
				child.gameObject.SetActive (false);
			}
		}
		else if (!cam.GetComponent<CameraMovement> ().isSelect) {
			foreach (Transform child in transform) {
				child.gameObject.SetActive (true);
			}
		}

	
	}
}
