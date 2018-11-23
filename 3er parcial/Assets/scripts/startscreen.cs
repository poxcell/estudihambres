using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startscreen : MonoBehaviour {

	public GameObject waitScreen;
	public GameObject InicioScreen;
	

	private bool waitingToStartGame = true;
	

	// Use this for initialization
	void Start () {
		

		if (waitScreen != null)
		{
			waitScreen.SetActive(true);
		}
		else
		{
			waitingToStartGame = false;
			Debug.LogError("waitScreen was not set in the inspector. Please set and try again");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (waitingToStartGame && (Input.GetButton("Submit")))
		{
			// set the flag to false so that will no longer be checking for input to start game
			waitingToStartGame = false;
			if (waitScreen != null)
			{

				InicioScreen.SetActive(true);
				StartCoroutine(startButtonPressed());
			//	
			}
			
		}
	}

	IEnumerator startButtonPressed()
	{
		yield return new WaitForSeconds(.5f);
		waitScreen.SetActive(false);
		
	}
}
