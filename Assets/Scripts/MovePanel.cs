using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel : MonoBehaviour {
    public float speed;
    Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

	void Update () {
        Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
        rb.transform.position -= movement;
    }
}
