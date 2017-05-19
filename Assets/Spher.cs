using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spher : MonoBehaviour {
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if (rb.position.y < -4) Destroy(gameObject);
	}
}
