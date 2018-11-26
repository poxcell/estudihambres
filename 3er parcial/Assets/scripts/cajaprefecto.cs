using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajaprefecto : MonoBehaviour
{
	public float daño;
	private float tiempo;
	public float wait;
	void Update()
	{
		if ( tiempo < wait)
		{
			tiempo += Time.deltaTime;
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (tiempo >= wait)
			{

			GetComponentInParent<PrefectoAnim>().Golpear();
			other.gameObject.GetComponent<Stats>().tomarDaño(daño);
				tiempo = 0;
			}
		}
	}
}
