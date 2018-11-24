using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stats : MonoBehaviour {
	[Tooltip("vida del personaje")]
	[SerializeField] private float vida;
	[Tooltip("vida maxima del personaje")]
	[SerializeField] private float maxvida;
	[Tooltip("rango del daño del golpe min,max")]
	[SerializeField] private Vector2 golpe;
	[SerializeField] private bool invencible;

	[Tooltip("tiempo para que te puedan volver a herir")]
	[SerializeField] private float reset;

	

	

	public float getVida()
	{
		return vida;
	}
	public float getGolpe()
	{
		
		return Random.Range(golpe.x, golpe.y);
	}
	
	
	void Update()
	{
		if (vida > maxvida)
		{
			vida = maxvida;
		}
		if(Input.GetKeyDown("space"))
		{
			tomarDaño(getGolpe());
			
		}
		if (vida <= 0)
		{
			this.gameObject.SetActive(false);
		}

	}

	void tomarDaño(float daño)
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
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			tomarDaño(other.transform.parent.GetComponent<Stats>().getGolpe());
		}
		if (other.gameObject.tag == "Vida")
		{
			//TODO hacer Vida
		}
	}


}
