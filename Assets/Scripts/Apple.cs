using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	private ApplePicker controller;

	void Start(){

		controller = GameObject.Find ("Main Camera").GetComponent<ApplePicker>();

	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Base") {
		
			Destroy (gameObject);
			controller.Restart();

		}

		if (other.tag == "Player") {

			Destroy (gameObject);
			controller.Count(10);

		}

	}

}
