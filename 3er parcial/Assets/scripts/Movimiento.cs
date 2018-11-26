using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
	List<GameObject> children = new List<GameObject>();
	[SerializeField] GameObject PausaObj;
	[SerializeField] private string NumeroDeControl;
	[SerializeField] private Transform camara;
	//velocidad de Movimiento
	public float velocidad = 10f;
	// fuerza de salto
	public float fuerzaSalto = 20f;
	public float minGravedad = -1.5f;
	public float gravedad = -9.8f;
	public float velterminal = -10f;

	public float rotate = 10f;
	private float vertSpeed;
	// multiplayer array
	private Animator[] animator = new Animator[4];
	private CharacterController control;

	private bool muerto;

	private bool knockback;

	private bool pausa = false;

	bool shit = true;
	[SerializeField] private float waitJump;
	private float timeElapsed;

	public string GetControl()
	{
		return NumeroDeControl;
	}

	public void UnPause()
	{
		pausa = false;
		this.gameObject.SetActive(true);
	}

	void Awake()
	{
		control = GetComponent<CharacterController>();
		vertSpeed = minGravedad;
		// multiplayer array
		animator = GetComponentsInChildren<Animator>();
		foreach(Animator anim in animator)
		{
			children.Add(anim.gameObject);
		}
		
	}
	public void TriggerGolpe()
	{
		foreach (Animator anim in animator)
		{
			anim.SetTrigger("Golpe");
		}
	}

	public void  SetMuerte(bool a)
	{
		muerto = a;
		
	}
	public void kncokbackOnDamage()
	{
		knockback = true;
		
		
		StartCoroutine(ResetKnockback());

	}
	IEnumerator ResetKnockback()
	{
		yield return new WaitForSeconds(.3f);
		knockback = false;

		// multi
		//for (int i = 0; i < animator.Length - 1; i++)
		//{
		//	animator[i].SetBool("knock", false);
		//}
		foreach (Animator anim in animator)
		{
			anim.SetBool("knock", false);
		}

	}
		void FixedUpdate()
	{
		Pause();
		if (Input.GetButtonDown("Joystick"+NumeroDeControl+"Lanzar"))
		{
			// multi
			//for (int i = 0; i < animator.Length - 1; i++)
			//{
			//	animator[i].SetTrigger("Lanzar");
			//}
			foreach (Animator anim in animator)
			{
				anim.SetTrigger("Lanzar");
			}
		}
		if (!muerto)
		{
			if (knockback)
			{
				knockbacked();
				//multi
				//for (int i = 0; i < animator.Length - 1; i++)
				//{
				//	animator[i].SetBool("knock", true);
				//}
				foreach (Animator anim in animator)
				{
					anim.SetBool("knock", true);
				}
			}
			if (!knockback)
			{
				if (!pausa)
				{

					movimientos();
				}

			}
		}
	}

	private void Pause()
	{
		if (Input.GetButtonDown("Submit"))
		{
			pausa = true;
			PausaObj.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}

	private void movimientos()
	{
		shit = true;
		// crea vector 3 en 0,0,0
		Vector3 movimiento = Vector3.zero;

		// reciven los movimientos del teclado/ control
		float deltaX = Input.GetAxis("Joystick" + NumeroDeControl + "LX");
		float deltaZ = -Input.GetAxis("Joystick" + NumeroDeControl + "LY");
		float deltaY = 0;



		Quaternion tmp = camara.rotation;

		movimiento = ExtraerMovimiento(movimiento, deltaX, deltaZ, tmp);

		// controla la animacion de movimiento
		// multi
		//for (int i = 0; i < animator.Length - 1; i++)
		//{
		//	animator[i].SetFloat("Speed", movimiento.magnitude / 10);
		//}
		foreach (Animator anim in animator)
		{
			anim.SetFloat("Speed", movimiento.magnitude/10);
		}

		deltaY = Salto();
		


		movimiento.y += deltaY;
		movimiento *= Time.deltaTime;



		control.Move(movimiento);
	}

	// fuerza del knockback
	private void knockbacked()
	{
		float flyback = -10f;



		// crea vector 3 en 0,0,0
		Vector3 movimiento = Vector3.zero;


		float deltaY = 0;


		Quaternion tmp = camara.rotation;

		movimiento = ExtraerMovimiento(movimiento, 0, flyback, tmp);

		//  TODO animacion knockback
		//animator.SetFloat("knockback", movimiento.magnitude / 10);


		if (shit)
		{
			shit = false;
			deltaY = fuerzaSalto * 5;
		}
		if (!shit)
		{

			deltaY += gravedad * 15 * Time.deltaTime;

			if (deltaY < velterminal)
			{
				deltaY = velterminal;
			}
		}






		movimiento.y += deltaY;
		movimiento *= Time.deltaTime;



		control.Move(movimiento);
	}

	private Vector3 ExtraerMovimiento(Vector3 movimiento, float deltaX, float deltaZ,Quaternion tmp)
	{
		if (deltaX !=0 || deltaZ != 0)
		{
			

			// multiplica la velocidad por la entrada del teclado
			movimiento.x = deltaX * velocidad;
			movimiento.z = deltaZ * velocidad;

			// extrae la rotacion en Y de la camara
			camara.eulerAngles = new Vector3(0, camara.eulerAngles.y, 0);

			// clampea la velocidad de X y Y para que no corra mas rapido en diagonal
			movimiento = Vector3.ClampMagnitude(movimiento, velocidad);

			// transforma el movimiento relativo a la direccion de la camara
			movimiento = camara.TransformDirection(movimiento);


			// rota al personaje relativo a la camara
			Quaternion direction = Quaternion.LookRotation(camara.forward);

			//suaviza la rotacion del personaje
			transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotate * Time.deltaTime);
			
		}

		

		return movimiento;
	}

	private float Salto()
	{

		if (control.isGrounded)
		{
			if (Input.GetButton("Joystick"+NumeroDeControl+"Jump"))
			{
				if (timeElapsed >= waitJump)
				{

					vertSpeed = fuerzaSalto;
					//multi
					/*
					for (int i = 0; i < animator.Length - 1; i++)
					{
						animator[i].SetBool("salto", true);
					}
					timeElapsed = 0;
					*/
					foreach (Animator anim in animator)
					{
						anim.SetBool("salto", true);
					}

				}
				
			}
			else
			{
				vertSpeed = minGravedad;
			}
			if (timeElapsed < waitJump)
			{
				timeElapsed += Time.deltaTime;
			}
		}
		else
		{
			vertSpeed += gravedad * 5 * Time.deltaTime;
			if (vertSpeed < velterminal)
			{
				vertSpeed = velterminal;
			}
			// multi
			/*
			for (int i = 0; i < animator.Length - 1; i++)
			{
				animator[i].SetBool("salto", false);
			}
			*/
			foreach (Animator anim in animator)
			{
				anim.SetBool("salto", false);
			}

		}
		return vertSpeed;
	}
}
