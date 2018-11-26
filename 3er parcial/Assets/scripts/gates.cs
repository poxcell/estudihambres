using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gates : MonoBehaviour {

	[SerializeField] private int NumMonedas;
	
	public bool usb;


	public void Destruir(int monedas)
	{
		if (!usb)
		{

			if (monedas >= NumMonedas)
			{
				Destroy(this.gameObject);
			}
		}
		
	}
	public void Recolectado()
	{
		Destroy(this.gameObject);
	}
}
