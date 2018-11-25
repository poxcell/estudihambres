using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarraPausa : MonoBehaviour {
	[SerializeField] private int seleccion;
	[SerializeField] private int[] Lugar = new int[4];
	RectTransform m_RectTransform;

	private bool m_isAxisInUse = false;



	private float num;
	[SerializeField] private GameObject jugador;
	[SerializeField] private GameObject controles;
	// Use this for initialization
	void Start () {
		m_RectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		MoverConDPad();
		ciclarSeleccion();
		moverBarra();

		if (Input.GetButtonDown("Jump") && seleccion == 0)
		{

			transform.parent.parent.gameObject.SetActive(false);
			jugador.GetComponent<Movimiento>().UnPause();
		}
		if (Input.GetButtonDown("Jump") && seleccion == 1)
		{

			controles.SetActive(true);
			transform.parent.gameObject.SetActive(false);
		}
		if (Input.GetButtonDown("Jump") && seleccion == 2)
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
