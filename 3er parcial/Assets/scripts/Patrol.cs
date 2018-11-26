using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
	public float speed;

	public Transform[] moveSpots;
	private int randomSpot;

	// Use this for initialization
	void Start () {
		randomSpot = Random.Range(0, moveSpots.Length);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
