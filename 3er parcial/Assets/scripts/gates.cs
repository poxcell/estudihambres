using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gates : MonoBehaviour {

	[SerializeField] private int NumMonedas;


	public void Destruir(int monedas)
	{
		if (monedas >= NumMonedas)
		{
			Destroy(this.gameObject);
		}
	}
}
