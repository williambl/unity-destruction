using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    public GameObject brokenObj;
    public GameObject togetherObj;

    // True if together, false if broken
    public bool together = true;

    public bool breakOnCollision = true;
    public float velocityToBreak = 1;


    // Use this for initialization
    void Start () {
        togetherObj.SetActive(true);
        brokenObj.SetActive(false);        
    }
	
    // Update is called once per frame
    void Update () {
        togetherObj.SetActive(together);
        brokenObj.SetActive(!together);
    }

    void OnCollisionEnter(Collision collision) {
        if (!breakOnCollision)
            return;
        if (collision.relativeVelocity.magnitude > velocityToBreak)
            together = false;
    }

}
