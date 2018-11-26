using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganar : MonoBehaviour
{
	public GameObject canvas;

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			canvas.SetActive(true);
		}
	}
}
