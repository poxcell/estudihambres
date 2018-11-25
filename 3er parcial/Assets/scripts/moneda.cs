using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
	public int valor;
	private GameObject Padre;


	void Awake()
	{
		Padre = transform.parent.gameObject;

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{

			Padre.GetComponent<Manager>().SetMonedasRecolectadas(valor);
			Destroy(this.gameObject);
		}

	}
}
