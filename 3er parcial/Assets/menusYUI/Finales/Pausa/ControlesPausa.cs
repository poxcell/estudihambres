using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesPausa : MonoBehaviour {
	[SerializeField] private GameObject Pausa;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Cancel"))
		{
			Pausa.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
