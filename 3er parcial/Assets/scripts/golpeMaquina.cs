using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golpeMaquina : MonoBehaviour {
	private GameObject maquina;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Soda")
		{
			other.GetComponent<SpawnSoda>().collision();
			
		}
	}
}
