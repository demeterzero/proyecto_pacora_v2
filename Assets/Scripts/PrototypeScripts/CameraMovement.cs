using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	//public float xAxis = Input.GetAxis("Horizontal");
	//public float yAxis = Input.GetAxis("Vertical");
	public float northLimit = 5, southLimit = 5, eastLimit = 5, westLimit = 5;
	public float camSpeed = 5.0f, lookSensitivity = 1, xRot, curXRot, yRot, curYRot, smoothSpeed = 0.1f, rotSpeed = 1, pastX, pastY, pastZ, botLimit =1, topLimit = 3;
	public bool canMove = true, QnECheck = false, rightClickCheck =false, isSelect = false;

	// Use this for initialization
	void Start () {

		yRot = transform.rotation.eulerAngles.y;
		xRot = transform.rotation.eulerAngles.x;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W) && canMove && transform.position.z < northLimit) {
			//transform.Translate(Vector3.forward * (Time.deltaTime * camSpeed), Space.World);
			this.gameObject.transform.Translate (new Vector3 (0, 0, 1) * camSpeed * Time.deltaTime);

			if((transform.position.x < westLimit && transform.rotation.y < 0) || (transform.position.x > eastLimit && gameObject.transform.rotation.y > 0)) {
				transform.position = new Vector3 (pastX, pastY, transform.position.z);
			} else {
				transform.position = new Vector3 (transform.position.x, pastY, transform.position.z);
			}

		}

		if (Input.GetKey (KeyCode.S) && canMove && transform.position.z > southLimit ) {
			//transform.Translate(Vector3.back * (Time.deltaTime * camSpeed), Space.World);
			this.gameObject.transform.Translate (Vector3.back * camSpeed * Time.deltaTime);

			if((transform.position.x < westLimit && transform.rotation.y > 0) || (transform.position.x > eastLimit && gameObject.transform.rotation.y < 0)) {
				transform.position = new Vector3 (pastX, pastY, transform.position.z);
			} else {
				transform.position = new Vector3 (transform.position.x, pastY, transform.position.z);
			}

		}
		//ADDING LINE TO LIMIT DIAGONAL MOVEMENTT

		if (Input.GetKey (KeyCode.A) && canMove && transform.position.x > westLimit) {
			//transform.Translate(Vector3.left * (Time.deltaTime * camSpeed), Space.World);
			this.gameObject.transform.Translate (Vector3.left * camSpeed * Time.deltaTime);

			if((transform.position.z < southLimit && transform.rotation.y < 0) || (transform.position.z > northLimit && gameObject.transform.rotation.y > 0)) {
				transform.position = new Vector3 (transform.position.x, pastY, pastZ);
			} else {
				transform.position = new Vector3 (transform.position.x, pastY, transform.position.z);
			}

		}

		if (Input.GetKey(KeyCode.D) && canMove && transform.position.x < eastLimit) {
			//transform.Translate(Vector3.right * (Time.deltaTime * camSpeed), Space.World);
			this.gameObject.transform.Translate(Vector3.right * camSpeed * Time.deltaTime);

			if((transform.position.z < southLimit && transform.rotation.y > 0) || (transform.position.z > northLimit && gameObject.transform.rotation.y < 0)) {
				transform.position = new Vector3 (transform.position.x, pastY, pastZ);
			} else {
				transform.position = new Vector3 (transform.position.x, pastY, transform.position.z);
			}

		}
			
		//CameraRotation
		if (Input.GetKey (KeyCode.Mouse1) && !QnECheck) {
			
			yRot -= Input.GetAxis ("Mouse X") * lookSensitivity;
			xRot += Input.GetAxis ("Mouse Y") * lookSensitivity;

			xRot = Mathf.Clamp (xRot, -20, 45);
			yRot = Mathf.Clamp (yRot, -60, 60);

			//curXRot = Mathf.SmoothDamp (curXRot, xRot, ref rotSpeed, smoothSpeed);
			//curYRot = Mathf.SmoothDamp (curYRot, yRot, ref rotSpeed, smoothSpeed);

			transform.rotation = Quaternion.Euler (xRot, yRot, transform.rotation.eulerAngles.z);

			rightClickCheck = true;

		}

		//THIS CHECK IS SET AFTER THE ROTATION OF Q AND E 
		QnECheck = false;

		if (Input.GetKey (KeyCode.Q) && !rightClickCheck) {

			yRot -= lookSensitivity;

			yRot = Mathf.Clamp (yRot, -60, 60);

			transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, yRot, transform.rotation.eulerAngles.z);

			QnECheck = true;
			
		}

		if (Input.GetKey (KeyCode.E) && !rightClickCheck) {
			
			yRot += lookSensitivity;

			yRot = Mathf.Clamp (yRot, -60, 60);

			transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, yRot, transform.rotation.eulerAngles.z);

			QnECheck = true;
		}

		//THIS CHECK IS SET AFTER THE ROTATION OF MOUSE1
		rightClickCheck = false;

		//Go Front Down
		if (Input.GetAxis ("Mouse ScrollWheel") > 0f && transform.position.y > botLimit) {

			//Scroll Up
			this.gameObject.transform.Translate(new Vector3(0,-2,3) * camSpeed * Time.deltaTime);

		}

		//Go Back Up
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0f && transform.position.y < topLimit) {

			//Scroll Down
			this.gameObject.transform.Translate(new Vector3(0,2,-3) * camSpeed * Time.deltaTime);
		}

		//Reset Camera position
		if (Input.GetKey (KeyCode.Space)) {
			yRot = 0;
			xRot = 0;
			transform.rotation = Quaternion.Euler (0, 0, 0);
		}

		//Register old positions
		pastX = transform.position.x;
		pastY = transform.position.y;
		pastZ = transform.position.z;

	}


	/*
	void LockMovement(){



	}


	void CheckBorders(){

		if (transform.position.z > northLimit) {
			northCheck = true;
		} else {
			northCheck = false;
		}

		if (transform.position.z < southLimit) {
			southCheck = true;
		} else {
			southCheck = false;
		}

		if (transform.position.x > westLimit) {
			westCheck = true;
		} else {
			westCheck = false;
		}

		if (transform.position.x < eastLimit) {
			eastCheck = true;
		} else {
			eastCheck = false;
		}
		
	}
	*/

}
