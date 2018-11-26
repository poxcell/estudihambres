using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaGolpe : MonoBehaviour {
	[SerializeField] private string NumeroDeControl;
	[SerializeField] GameObject cajaObj;
	[SerializeField] Animator animaciones;
	// Use this for initialization
	void Start () {
		NumeroDeControl = this.gameObject.GetComponent<Movimiento>().GetControl();
		animaciones = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Joystick" + NumeroDeControl + "Golpe"))
		{
			GetComponentInParent<Movimiento>().TriggerGolpe();
			cajaObj.GetComponent<Golpe>().HacerDaño();
		}
	}
}
