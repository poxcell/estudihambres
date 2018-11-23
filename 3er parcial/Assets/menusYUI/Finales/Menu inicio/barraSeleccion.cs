using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class barraSeleccion : MonoBehaviour {
	[SerializeField] private int seleccion;
	[SerializeField] private int[] Lugar = new int[4];
	[SerializeField] private GameObject controles;
	[SerializeField] private GameObject creditos;
	[SerializeField] private GameObject carga;
	public GameObject animator;

	RectTransform m_RectTransform;

	private bool m_isAxisInUse = false;

	private float num;
	

	


	void Start () {
		m_RectTransform = GetComponent<RectTransform>();

		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		ciclarSeleccion();
		moverBarra();
		
		MoverConDPad();
		controles.SetActive(true);


		if (Input.GetButtonDown("Jump") && seleccion == 0)
		{
			carga.SetActive(true);
			desactivarInicio();
			StartCoroutine(LoadYourAsyncScene());
		}
		if (Input.GetButtonDown("Jump") && seleccion == 1)
		{
			controles.SetActive(true);
			desactivarInicio();
		}
		if (Input.GetButtonDown("Jump") && seleccion == 2)
		{
			creditos.SetActive(true);
			desactivarInicio();
		}
		if (Input.GetButtonDown("Jump") && seleccion == 3)
			Application.Quit();







	}

	private void desactivarInicio()
	{
		animator.GetComponent<Animator>().SetBool("inicioOut", true);
		StartCoroutine(desactivarScreen());
	}

	IEnumerator desactivarScreen()
	{
		yield return new WaitForSeconds(.1f);
		animator.SetActive(false);
		

	}

	IEnumerator LoadYourAsyncScene()
	{
		// The Application loads the Scene in the background as the current Scene runs.
		// This is particularly good for creating loading screens.
		// You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
		// a sceneBuildIndex of 1 as shown in Build Settings.

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("testlvl");

		// Wait until the asynchronous scene fully loads
		while (!asyncLoad.isDone)
		{
			yield return null;
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
