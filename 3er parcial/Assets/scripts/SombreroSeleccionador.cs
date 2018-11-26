using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombreroSeleccionador : MonoBehaviour {
	[SerializeField] private GameObject[] personajes;
	public int seleccion;
	
	private float num;

	// Use this for initialization
	void Awake () {
		CambiarPersonaje();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetAxisRaw("Joystick1Up") != 0)
		{
			
				num = (Input.GetAxisRaw("Joystick1Up"));

				if (num < 0)
				{
					seleccion = 1;
				}
				if (num > 0)
				{
					seleccion = 0;
				}
			CambiarPersonaje();



		}
		else if (Input.GetAxisRaw("Joystick1LeRi") != 0)
		{

			num = (Input.GetAxisRaw("Joystick1LeRi"));

			if (num < 0)
			{
				seleccion = 3;
			}
			if (num > 0)
			{
				seleccion = 2;
			}
			CambiarPersonaje();


		}


	}

	void CambiarPersonaje()
	{
		for (int i = 0; i < personajes.Length; i++)
		{
			if (i != seleccion)
			{
				personajes[i].gameObject.SetActive(false);
			}
			else
			{
				personajes[i].gameObject.SetActive(true);
			}
		}
	}

	
}
