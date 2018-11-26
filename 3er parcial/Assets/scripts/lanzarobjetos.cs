using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzarobjetos : MonoBehaviour {
	[SerializeField] private string NumeroDeControl;
	[SerializeField] GameObject[] objeto;
	[SerializeField] int seleccion;
	public float time;
	[SerializeField] private Transform spawnPoint;
	private float timeElapsed;
	public float wait;


	void FixedUpdate () {
		if (timeElapsed >= wait && Input.GetButtonDown("Joystick" + NumeroDeControl + "Lanzar"))
		{
			
				StartCoroutine(LanzarObjeto());
				timeElapsed = 0;
			
		}
		else
		{
			timeElapsed += Time.deltaTime;
		}
	}
	IEnumerator LanzarObjeto()
	{
		yield return new WaitForSeconds(time);
		GameObject clone = Instantiate(objeto[seleccion], spawnPoint.position, spawnPoint.rotation);
		clone.GetComponent<objetoDaño>().SetPersonaje(this.gameObject);
		Destroy(clone, 5f);
	}
	public string getControl()
	{
		return NumeroDeControl;
	}
}
