using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour {
	private GameObject Enemy = null;
	private string NumeroDeControl;
	[SerializeField] private Vector3 offset;
	private Vector3 EnemyOffset;
	void Awake()
	{
		NumeroDeControl = transform.parent.gameObject.GetComponent<lanzarobjetos>().getControl();
	}

	void Update()
	{


		if (Input.GetButtonDown("Joystick" + NumeroDeControl + "Apuntar"))
		{
			Enemy = transform.parent.gameObject.GetComponent<ClosestEnemy>().GetEnemy();
		}
		if (Input.GetButtonUp("Joystick" + NumeroDeControl + "Apuntar"))
		{
			Enemy = null;
		}
		if (Enemy != null)
		{
			EnemyOffset = Enemy.transform.position + offset;
			transform.LookAt(EnemyOffset);
			
		}
	}
}
