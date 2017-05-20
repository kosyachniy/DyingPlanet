using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spher : MonoBehaviour {
	Rigidbody rb;
	public Panel panel;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		if (rb.position.y < -4 || rb.position.y > 10) {
			Destroy(gameObject);
		}
	}
}
