using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usb : MonoBehaviour {
	public GameObject gate;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Destroy(this.gameObject);
			gate.GetComponent<gates>().Recolectado();

		}
	}
}
