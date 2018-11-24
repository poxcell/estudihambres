using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startfade : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Awake() {
		animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Submit"))
		{
			animator.SetBool("StartFade", true);
		}
	}
}
