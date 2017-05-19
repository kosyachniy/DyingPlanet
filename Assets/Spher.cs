using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spher : MonoBehaviour {
	rigidbody myRigidbody;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (myRigidbody.position.y < 3) Destroy(gameObject);
	}
}
