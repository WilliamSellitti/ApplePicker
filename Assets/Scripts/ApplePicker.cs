using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public float bottomLayer;
	public GUIText score;
	public GUIText gameOver;
	public GUIText highScore;

	private float basketSpacing;
	private int scorePoints;
	static private int highScorePoints = 0;
	private List<GameObject> basketList;

	// Use this for initialization
	void Start () {
	
		basketList = new List<GameObject> ();

		scorePoints = 0;

		score.text = "Current Score: " + scorePoints.ToString();
		highScore.text = "High Score: " + highScorePoints;
		gameOver.text = "";

		basketSpacing = .6f;

		for (int i = 0; i < 3; i++) {

			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = bottomLayer + (basketSpacing * i);
			tBasketGO.transform.position = pos;
			basketList.Add ( tBasketGO );
		
		}

	}

	public void Count(int x){

		scorePoints += x;
		score.text = "Current Score: " + scorePoints.ToString();

	}

	public void Restart(){

		GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
		foreach( GameObject appleGO in apples){

			Destroy(appleGO);

		}

		int basketIndex = basketList.Count - 1; //keeps count of lives lost
		GameObject tBasketGO = basketList [basketIndex]; 
		basketList.RemoveAt (basketIndex); //destroys record of previous lives
		Destroy (tBasketGO); // same as above

		if (basketList.Count == 0) {

			if(highScorePoints < scorePoints){

				highScorePoints = scorePoints;

			}

			gameOver.text = "Game Over, Press 'R' to restart.";
			highScore.text = "High Score: " + highScorePoints;

			Application.LoadLevel("Scene 1");

		}

	}

}
