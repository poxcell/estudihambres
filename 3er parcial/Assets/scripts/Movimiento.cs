using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
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
	private Animator animator;
	private CharacterController control;
	
	void Awake()
	{
		control = GetComponent<CharacterController>();
		vertSpeed = minGravedad;
		animator = GetComponentInChildren<Animator>();
	}


	void FixedUpdate()
	{
		// crea vector 3 en 0,0,0
		Vector3 movimiento = Vector3.zero;

		// reciven los movimientos del teclado/ control
		float deltaX = Input.GetAxis("Joystick"+NumeroDeControl+"LX");
		float deltaZ = -Input.GetAxis("Joystick" + NumeroDeControl + "LY");
		float deltaY = 0;



		Quaternion tmp = camara.rotation;

		movimiento = ExtraerMovimiento(movimiento, deltaX, deltaZ, tmp);

		// controla la animacion de movimiento
		animator.SetFloat("Speed", movimiento.magnitude/10);
		

		deltaY = Salto();
		

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
				vertSpeed = fuerzaSalto;
			}
			else
			{
				vertSpeed = minGravedad;
			}
		}
		else
		{
			vertSpeed += gravedad * 5 * Time.deltaTime;
			if (vertSpeed < velterminal)
			{
				vertSpeed = velterminal;
			}

		}
		return vertSpeed;
	}
}
