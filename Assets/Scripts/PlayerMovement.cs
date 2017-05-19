using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    //Vector3 pos = new Vector3(0,0,0);
    bool l = false;
    bool r = false;
    Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

	void Update () {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(h * speed, rb.velocity.y, v * speed);   //rb.velocity.y
        //rb.AddForce(movement);

		if (rb.position.y < 5) { //Высота прыжка
            if (Input.GetButtonDown("Jump"))
                rb.velocity = new Vector3(0, 10, 0);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            rb.velocity = new Vector3(0, 0, 5);
            //pos = new Vector3(rb.position.x, rb.position.y, rb.position.z + 5);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            l = false;
            r = true;
            rb.velocity = new Vector3(-5, 0, 0);
            //pos = new Vector3(rb.position.x - 5, rb.position.y, rb.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            l = true;
            r = false;
			//DateTime tim = DateTime.Now;
            rb.velocity = new Vector3(5, 0, 0);
            //pos = new Vector3(rb.position.x + 5, rb.position.y, rb.position.z);
        }
		//DateTime x = DateTime.Now;
    }
}
