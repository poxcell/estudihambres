using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetomovimiento : MonoBehaviour {
	[SerializeField] private float velocidad;
	

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * velocidad);
		
	}
}
