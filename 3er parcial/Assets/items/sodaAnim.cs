using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sodaAnim : MonoBehaviour
{
	public float CantidadVida;
	public float amplitud;
	public float OmegaY;
	float index;


	// Update is called once per frame
	void Update()
	{
		index += Time.deltaTime;
		float y = Mathf.Abs(amplitud * Mathf.Sin(OmegaY * index));
		transform.localPosition = new Vector3(transform.position.x, y, transform.position.z);
	}
	private void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Player")
		{
			if (other.GetComponent<Stats>().CanHeal())
			{
				
				other.GetComponent<Stats>().tomarVida(CantidadVida);
				{
					Destroy(this.gameObject);
				}
			}
		}


	}
}
