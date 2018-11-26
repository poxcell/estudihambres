using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzarobjetos : MonoBehaviour {
	[SerializeField] private string NumeroDeControl;
	[SerializeField] GameObject[] objeto;
	[SerializeField] int seleccion;

	[SerializeField] Transform spawnPoint;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Joystick" + NumeroDeControl + "Lanzar"))
		{

		}
	}
}
