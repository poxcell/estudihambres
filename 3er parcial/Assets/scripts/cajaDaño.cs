using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajaDaño : MonoBehaviour {

	[Tooltip("rango del daño del golpe min,max")]
	[SerializeField] private Vector2 golpe;
	private GameObject personaje;

	// Use this for initialization
	void Awake () {
		personaje = this.transform.parent.gameObject;
	}
	


	public float getGolpe()
	{

		return Random.Range(golpe.x, golpe.y);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (personaje.tag != other.tag)
		{
				 
			if (other.tag == "Player")
			{
				other.GetComponent<Stats>().tomarDaño(getGolpe());
			}
		}
	}

}
