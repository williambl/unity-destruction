using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    public GameObject ball;
    public float forceMultiplier;
    Camera camera;

    void Start () {
        camera = GetComponent<Camera>();
    }
	
    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            GameObject newBall = Instantiate(ball, ray.origin, Quaternion.Euler(Vector3.zero));
            newBall.GetComponent<Rigidbody>().AddForce(ray.direction * forceMultiplier);
        }
    }
}
