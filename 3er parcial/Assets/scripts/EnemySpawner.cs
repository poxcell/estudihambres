using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	private float nextSpawnTime;
	[SerializeField] GameObject americano;
	[SerializeField] GameObject prefecto;
	[SerializeField] float SpawnDelay;
	[SerializeField] bool isamericano;
	[SerializeField] bool isprefecto;
	
		


	// Update is called once per frame
	void Update () {
		if (ShouldSpawn())
		{
			Spawn();
		}
	}

	private void Spawn()
	{
		nextSpawnTime = Time.time + SpawnDelay;
		if (isamericano)
		{
			GameObject clone = Instantiate(americano, transform.position, transform.rotation);

			
		}
		if (isprefecto)
		{
			GameObject clone = Instantiate(prefecto, transform.position, transform.rotation);
			
		}
	}

	private bool ShouldSpawn()
	{
		return Time.time >= nextSpawnTime;
	}
}
