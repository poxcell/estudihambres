using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TMPS : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
		textmeshPro.SetText("The first number is {0} and the 2nd is {1:2} and the 3rd is {3:0}.", 4, 6.345f, 3.5f);
	}
}
