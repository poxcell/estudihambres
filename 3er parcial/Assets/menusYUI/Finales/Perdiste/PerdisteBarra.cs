using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerdisteBarra : MonoBehaviour {

	[SerializeField] private int seleccion;
	[SerializeField] private int[] Lugar = new int[4];

	[SerializeField] private GameObject jugador;

	RectTransform m_RectTransform;

	private bool m_isAxisInUse = false;



	private float num;

	// Use this for initialization
	void Start () {
		m_RectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		ciclarSeleccion();
		MoverConDPad();
		moverBarra();

		if (Input.GetButtonDown("Jump") && seleccion == 0)
		{
			
			jugador.GetComponent<Stats>().RespawnSingle();
		}
		if (Input.GetButtonDown("Jump") && seleccion == 1)
		{
			SceneManager.LoadSceneAsync("menu");
		}
		
	}
	private void ciclarSeleccion()
	{
		if (seleccion > Lugar.Length - 1)
		{
			seleccion = 0;
		}
		if (seleccion < 0)
		{
			seleccion = Lugar.Length - 1;
		}
	}
	private void MoverConDPad()
	{
		if (Input.GetAxisRaw("Joystick1Up") != 0)
		{
			//moverBarra();
			if (m_isAxisInUse == false)
			{
				m_isAxisInUse = true;

				num = (Input.GetAxisRaw("Joystick1Up"));
				if (num < 0)
				{
					seleccion++;
				}
				if (num > 0)
				{
					seleccion--;
				}

			}

		}

		if (Input.GetAxisRaw("Joystick1Up") == 0)
		{
			m_isAxisInUse = false;
		}
	}
	void moverBarra()
	{
		m_RectTransform.anchoredPosition = new Vector2(m_RectTransform.anchoredPosition.x, Lugar[seleccion]);
	}
}
