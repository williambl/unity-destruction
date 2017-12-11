using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionChild : MonoBehaviour {

    public Destruction parent;

    // Use this for initialization
    void Start () { 
    }
	
    void OnCollisionEnter(Collision collision) {
        if (collision.relativeVelocity.magnitude > 1)
            parent.together = false;
    }


}
