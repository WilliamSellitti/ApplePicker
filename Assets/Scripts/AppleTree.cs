using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	public GameObject applePrefab;
	public float speed;
	public float changeDirectionsTime;
	public float timeBetweenApples;

	public Edge edges;

	private bool changeDirections;
	private float lastChangeAttempt;
	
	void Start () {
	
		changeDirections = false;
		lastChangeAttempt = Time.time;
		InvokeRepeating ("DropApple", 2f, timeBetweenApples);

	}

	void Update () {
	
		//makes the apple tree go
		Vector3 pos = transform.position;

		//decides if the apple should change directions
		if ( transform.position.x < edges.left ) {
			
			speed = speed * -1;
			
		} else if ( transform.position.x > edges.right ) {
			
			speed = speed * -1;
			
		}

		//random direction
		if (!changeDirections) {

			if(Random.value > 0.8){

				speed = speed * -1;

			}

			changeDirections = true;
			lastChangeAttempt = Time.time;

		}

		//sends the apple to its next location from wherever it currently is
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//sets check
		if (Time.time > (lastChangeAttempt + (Time.deltaTime * changeDirectionsTime)) ) {

			changeDirections = false;

		}

	}

	void DropApple(){

		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;

	}

}

[System.Serializable]
public class Edge{

	public float left;
	public float right;

	// Use this for initialization
	void Start () {
		
	}

}