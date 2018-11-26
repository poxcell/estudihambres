using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoDaño : MonoBehaviour {
	[Tooltip("rango del daño del golpe min,max")]
	[SerializeField] private Vector2 golpe;
	private GameObject personaje;
	[SerializeField] private bool DestroyOnContact;

	public void SetPersonaje(GameObject a)
	{
		personaje = a;
	}
	public float getGolpe()
	{

		return Random.Range(golpe.x, golpe.y);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (personaje.tag != other.tag)
		{
			/*	 
			if (other.tag == "Player")
			{
				other.GetComponent<Stats>().tomarDaño(getGolpe());
				if (canKnockback)
				{
					other.GetComponent<Movimiento>().kncokbackOnDamage();
				}
			}
			*/
			if ((other.tag == "Player" || other.tag == "Enemy") && other.tag != personaje.tag)
			{
				other.GetComponent<Stats>().tomarDaño(getGolpe());
				
				if (DestroyOnContact)
				{
					Destroy(this.gameObject);
				}
			}

		}
	}

}
