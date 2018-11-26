using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemy : MonoBehaviour {

	private GameObject Enemyname;
	public float Distancia;
	void Start()
	{
		Enemyname = null;
	}
	void Update()
	{
		Enemyname = FindClosestEnemy();
	}

	public	GameObject GetEnemy()
	{
		return Enemyname;
	}


	public GameObject FindClosestEnemy()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Distancia;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}


}
