using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaGolpe : MonoBehaviour {
	[SerializeField] private string NumeroDeControl;
	[SerializeField] GameObject cajaObj;
	[SerializeField] GameObject animaciones;
	// Use this for initialization
	void Start () {
		NumeroDeControl = this.gameObject.GetComponent<Movimiento>().GetControl();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Joystick" + NumeroDeControl + "Golpe"))
		{
			animaciones.GetComponent<Animator>().SetTrigger("Golpe");
			cajaObj.GetComponent<Golpe>().HacerDaño();
		}
	}
}
