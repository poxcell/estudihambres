using System;
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
	[SerializeField] private bool respawneable;

	[Tooltip("tiempo para que te puedan volver a herir")]
	[SerializeField] private float RespawnTiempo;
	

	private Vector3 RespawnPos;


	

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
			

			if (respawneable)
			{
			GetComponentInChildren<Animator>().SetBool("muerto", true);
			this.GetComponent<Movimiento>().SetMuerte(true);
				
				StartCoroutine(Respawn());
			}
			if (!respawneable)
			{
				GetComponentInChildren<Animator>().SetBool("muerto", true);
				StartCoroutine(MuerteEnemy());
			}
		}

	}

	IEnumerator Respawn()
	{
		yield return new WaitForSeconds(RespawnTiempo);

		this.GetComponent<Movimiento>().SetMuerte(false);
		GetComponentInChildren<Animator>().SetBool("muerto", false);
		vida = maxvida;



		transform.position = RespawnPos;
	}
	IEnumerator MuerteEnemy()
	{
		yield return new WaitForSeconds(RespawnTiempo);
		Destroy(this.transform.parent.gameObject);
	}
	// llamar para recibir daño
	public void tomarDaño(float daño)
	{
		if (!invencible)
		{
			vida -= daño;
		}
		
	}
	
	// llamar para recibir vida
	void tomarVida(float vidai)
	{
		vida += vidai;
	}



	// guarda la posicion de un objeto con tag Respawn
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Respawn")
		{
			RespawnPos = other.transform.position;
		}
	}
	



}
