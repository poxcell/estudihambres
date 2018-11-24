using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stats : MonoBehaviour {
	[Tooltip("vida del personaje")]
	[SerializeField] private float vida;
	[Tooltip("vida maxima del personaje")]
	[SerializeField] private float maxvida;
	
	[SerializeField] private bool invencible;

	[Tooltip("tiempo para que te puedan volver a herir")]
	[SerializeField] private float reset;

	

	

	public float getVida()
	{
		return vida;
	}
	
	
	void Update()
	{
		if (vida > maxvida)
		{
			vida = maxvida;
		}
		
		if (vida <= 0)
		{
			//this.gameObject.SetActive(false);

		}

	}

	public void tomarDaño(float daño)
	{
		if (!invencible)
		{
			vida -= daño;
		}
		
	}

	void tomarVida(float vidai)
	{
		vida += vidai;
	}
	


}
