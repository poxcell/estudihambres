using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour {
	private int MonedasRecolectadas;
	public Text Monedas;

	public GameObject[] gatesobject;
	

	public int GetMonedasRecolectadas()
	{
		return MonedasRecolectadas;
	}
	public void SetMonedasRecolectadas(int a)
	{
		MonedasRecolectadas += a;
		SetUIMonedas();

		if (gatesobject != null)
		{

		for (int i = 0; i < gatesobject.Length; i++)
		{
			gatesobject[i].GetComponent<gates>().Destruir(MonedasRecolectadas);
		}
		}
	}

	private void SetUIMonedas()
	{
		Monedas.text = "Monedas: " + MonedasRecolectadas;
	}
	
	
}
