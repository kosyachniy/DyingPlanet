using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {
    public float speed;
    float WaitTime = 0.3f;
    List<GameObject> panels = new List<GameObject>();

	void Start () {}

	void Update () {
        WaitTime -= Time.deltaTime;
        if (WaitTime <= 0) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //cube.AddComponent<Rigidbody>();
            cube.transform.localScale = new Vector3(5, 0.1f, 5);
            cube.transform.Rotate(new Vector3(0, 0, 0));
            cube.transform.position = new Vector3(Random.Range(-15, 15), 0, 30);
            panels.Add(cube);
            WaitTime = 0.3f;
        }
        Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
        for (int i = 0; i < panels.Count; i++) {
           panels[i].transform.position -= movement;
        }
    }
}
