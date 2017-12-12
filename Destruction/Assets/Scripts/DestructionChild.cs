using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionChild : MonoBehaviour {

    public Destruction parent;

    public bool breakOnCollision = true;
    public float velocityToBreak = 1;

    // Use this for initialization
    void Start () { 
    }
	
    void OnCollisionEnter(Collision collision) {
        if (!breakOnCollision)
            return;
        if (collision.relativeVelocity.magnitude > velocityToBreak)
            parent.together = false;
    }


}
