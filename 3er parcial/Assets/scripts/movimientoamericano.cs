using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoamericano : MonoBehaviour {

	[SerializeField] private float velocidad;
	private bool enMovimiento = true;
	[SerializeField] private float reducirVelocidad;
	// Update is called once per frame
	void Update () {
		
		if (enMovimiento)
		{

		transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
		}
		else
		{
			reducirVelocidad += reducirVelocidad * Time.deltaTime;
			transform.Translate(Vector3.forward * Time.deltaTime * (velocidad/reducirVelocidad) );
		}
	}
	public void DetenerMovimiento()
	{
		enMovimiento = false;	
	}
}
