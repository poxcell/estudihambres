using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour {
	private GameObject padre;
	public float daño;
	public float wait;
	// Use this for initialization
	void Start () {
		padre = transform.parent.gameObject;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.GetComponent<Stats>().tomarDaño(daño);
		}
	}
	public void HacerDaño()
	{
		this.gameObject.GetComponent<BoxCollider>().enabled = true;
		StartCoroutine(ResetGolpe());
	}
	IEnumerator ResetGolpe()
	{
		yield return new WaitForSeconds(wait);
		this.gameObject.GetComponent<BoxCollider>().enabled = false;
	}
}
