using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoda : MonoBehaviour {

	[SerializeField] GameObject Soda;

	public void collision()
	{
		Debug.Log("asdf");
		
		GameObject soda = Instantiate(Soda, transform.position, transform.rotation);
		
	}
}
