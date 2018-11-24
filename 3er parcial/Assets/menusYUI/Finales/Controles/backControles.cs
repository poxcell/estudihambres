using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backControles : MonoBehaviour {

	public GameObject inicio;
		
	void Update () {
		if (Input.GetButtonDown("Cancel"))
		{
			this.gameObject.SetActive(false);
			inicio.SetActive(true);
			
		}
		
	}
}
