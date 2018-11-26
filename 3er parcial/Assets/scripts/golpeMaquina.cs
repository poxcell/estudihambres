using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golpeMaquina : MonoBehaviour {

	 void OnTriggerEnter(Collider other)
	{

		Debug.Log("asdfasdf");
		if (other.tag == "Maquina")
		{
			Debug.Log("ferfergerger");
			//other.GetComponent<SpawnSoda>().collision();
		}
	}
}
