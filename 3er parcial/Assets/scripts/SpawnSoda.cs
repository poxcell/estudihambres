using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoda : MonoBehaviour {

	[SerializeField] GameObject Soda;
	[SerializeField] GameObject Spawn;

	[SerializeField] int Cantidad;
	public void collision()
	{

		if (Cantidad>0)
		{

		GameObject soda = Instantiate(Soda, Spawn.transform.position, transform.rotation);
			Cantidad --;
		}
		
	}
}
