using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spher : MonoBehaviour {
	Rigidbody myRigidbody;

	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
	}

	void Update () {
		if (myRigidbody.position.y < 3) Destroy(gameObject);
	}
}
