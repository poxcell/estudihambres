using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawner : MonoBehaviour {
	private GameObject enemy;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			enemy = other.gameObject;
			//Debug.Log( other.GetComponent<taclear>().name);

			//Debug.Log(other.gameObject.name); 

			Destroy(enemy,3);
			enemy.GetComponent<Animator>().SetTrigger("tacle");
			enemy.GetComponent<movimientoamericano>().DetenerMovimiento();
			enemy = null;
		}
		else
		{
			Debug.Log("null");
		}
	}
}
