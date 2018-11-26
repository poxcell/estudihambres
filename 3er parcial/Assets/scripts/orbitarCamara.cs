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
	public GameObject enemigo;
	private bool lockON;

	public float lockedHeight;

	public Vector3 lockedOffset;
	
	void Awake()
	{
		_roty = transform.eulerAngles.y;
		_rotx = transform.eulerAngles.y;
		enemigo = null;
	}

	void Update() {

		if (Input.GetButtonDown("Joystick" + NumeroDeControl + "Apuntar"))
		{
			enemigo = transform.parent.GetComponentInChildren<ClosestEnemy>().GetEnemy();
			lockON = true;
		}
		if (Input.GetButtonUp("Joystick" + NumeroDeControl + "Apuntar"))
		{
			enemigo = null;
			lockON = false;
		}
		if (enemigo != null)
		{
			if (lockON)
			{

			lockOnenemy();
			}
			else
			{

				lockonPlayer();
			}
		}
		else
		{
			lockonPlayer();
		}
		
		
	}

	private void lockonPlayer()
	{
		enemigo = null;

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

	private void lockOnenemy()
	{
		

			float dx = (personaje.position.x - enemigo.transform.position.x);
			float dz = (personaje.position.z - enemigo.transform.position.z);


			Vector3 posicionar = new Vector3(0, dist, 0);
			posicionar += enemigo.transform.position;



			Vector3 rotacion;
			rotacion.x = Mathf.Clamp(dx, -1, 1);
			rotacion.z = Mathf.Clamp(dz, -1, 1);
			rotacion.y = 0;

			/*
			if (rotacion.x >0)
			{
				rotacion.x = 1;
			}
			else if (rotacion.x < 0)
			{
				rotacion.x = -1;
			}

			if (rotacion.z > 0)
			{
				rotacion.z = 1;
			}
			else if (rotacion.z < 0)
			{
				rotacion.z = -1;
			}
			*/


			//Vector3 newpos = Vector3.Scale(new Vector3(rotacion.ToEuler()), lockedOffset);

			Vector3 newpos = new Vector3(rotacion.x * lockedOffset.x, lockedHeight, rotacion.z * lockedOffset.z);

			transform.localPosition = personaje.position + newpos ;
		
			//transform.position = personaje.position - (rotacion * newpos) ;

			//transform.position += new Vector3(0, lockedHeight, 0);


		
			transform.LookAt(enemigo.transform.position);
		

		
	}
}
