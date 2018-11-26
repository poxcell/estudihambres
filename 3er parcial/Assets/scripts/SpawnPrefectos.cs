using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefectos : MonoBehaviour {

	public GameObject Prefecto;
	public GameObject Prefectos;

	void Update()
	{
		if (!Prefecto )
		{
			Prefectos.SetActive(true);
		}
	}
}
