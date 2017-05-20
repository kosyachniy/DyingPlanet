using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : MonoBehaviour {
    public float speed;
    Rigidbody rb;
	public bool t =true;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

	void Update () {
		if (t) {
			Vector3 movement = new Vector3 (0, 0, speed * Time.deltaTime);
			rb.transform.position -= movement;
		}
    }
}
