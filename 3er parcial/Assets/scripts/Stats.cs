using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class Stats : MonoBehaviour {
	[Tooltip("vida del personaje")]
	[SerializeField] private float vida;
	[Tooltip("vida maxima del personaje")]
	[SerializeField] private float maxvida;
	
	[SerializeField] private bool invencible;
	[SerializeField] private bool respawneable;

	[Tooltip("tiempo para que te puedan volver a herir")]
	[SerializeField] private float RespawnTiempo;


	[SerializeField] private int vidas;


	private Vector3 RespawnPos;

	public Image healthBar;



	[SerializeField] private GameObject ReprobasteScreen;


	void Awake()
	{
		actualizarBarraVida();
	}

	

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
				
				// multiplayer StartCoroutine(Respawn());

				// singleplayer
				ReprobasteScreen.SetActive(true);
			}
			if (!respawneable)
			{
				GetComponentInChildren<Animator>().SetBool("muerto", true);
				StartCoroutine(MuerteEnemy());
				this.gameObject.GetComponent<Animator>().SetTrigger("muerte");
			}
		}

	}
	// respawn multiplayer
	IEnumerator Respawn()
	{
		

			yield return new WaitForSeconds(RespawnTiempo);

			this.GetComponent<Movimiento>().SetMuerte(false);
			GetComponentInChildren<Animator>().SetBool("muerto", false);
			vida = maxvida;


			actualizarBarraVida();
			transform.position = RespawnPos;
			
		
	}

	//respawn singleplayer

	public void RespawnSingle()
	{
		if (vidas > 0)
		{
			this.GetComponent<Movimiento>().SetMuerte(false);
			GetComponentInChildren<Animator>().SetBool("muerto", false);
			vida = maxvida;


			actualizarBarraVida();
			transform.position = RespawnPos;
			ReprobasteScreen.SetActive(false);
			vidas--;
		}
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

		actualizarBarraVida();
		this.gameObject.GetComponent<Animator>().SetTrigger("dano");
	}
	
	private void actualizarBarraVida()
	{
		if (healthBar)
		{

			healthBar.fillAmount = vida / maxvida;
		}
	}
	// llamar para recibir vida
	void tomarVida(float vidai)
	{
		vida += vidai;
		actualizarBarraVida();
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
