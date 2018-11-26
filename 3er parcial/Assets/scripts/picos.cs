using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picos : MonoBehaviour {
	public float daño;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<Stats>().tomarDaño(daño);
			other.gameObject.GetComponent<Movimiento>().TriggerDaño();
		}
	}
}
