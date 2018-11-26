using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrefectoAnim : MonoBehaviour {
	private Animator animator;
	private NavMeshAgent navAgent;
	public float speed;
	// Use this for initialization
	void Awake () {
		animator = GetComponentInChildren<Animator>();
		navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		speed = navAgent.velocity.magnitude;
		animator.SetFloat("speed", speed);
	}
	public void Golpear()
	{
		animator.SetTrigger("Golpe");
	}
}
