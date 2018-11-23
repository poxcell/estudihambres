using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitarCamara : MonoBehaviour {
	[SerializeField] private string NumeroDeControl;
	[SerializeField] private Transform personaje;

	public float velocidad = 5f;
	public Vector3 offset;
	public float dist = 0f;

	private float _roty;
	private float _rotx = -25f;

	public float min = -45f;
	public float max = 45f;

	

	void Awake()
	{
		_roty = transform.eulerAngles.y;
		_rotx = transform.eulerAngles.y;
	}
	
	void Update () {
		// vector de offset de posicion
		Vector3 posicionar = new Vector3(0, dist, 0);
		posicionar += personaje.position;

		// recive el movimiento del mouse, clampea en y entre min y max
		_roty += Input.GetAxis("Joystick" + NumeroDeControl + "RY") * velocidad * 0.4f;
		_rotx += Input.GetAxis("Joystick" + NumeroDeControl + "RX") * velocidad * 0.4f;
		_rotx = Mathf.Clamp(_rotx, min, max);

		// convierte en quaternion
		Quaternion rotacion = Quaternion.Euler(_rotx, _roty, 0);

		// mueve la camara con respecto al personaje y su offset de posicion, y orbita su posicion actual
		transform.position = posicionar - (rotacion * offset);
		// gira la rotacion de la camara para observar hacia el personaje
		transform.LookAt(posicionar);
	}
}
