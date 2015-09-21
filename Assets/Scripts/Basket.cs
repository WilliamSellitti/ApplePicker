using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public Edge edge;

	void Update () {
		
		Vector3 mousePos2D = Input.mousePosition; //gets mouse coordinates
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;

	}

}
