using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    [Header("Game Objects")]
    public GameObject brokenObj;
    public GameObject togetherObj;

    // True if together, false if broken
    [Space(10)]
    [Header("State")]
    public bool together = true;

    [Space(10)]
    [Header("Breaking on Collision")]
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
            Break();
    }

    public void Break () {
        together = false;
    }

    public void BreakWithExplosiveForce(float force, float radius = 3) {
        Break();
        foreach (Rigidbody rigid in brokenObj.GetComponentsInChildren<Rigidbody>()) {
            rigid.AddExplosionForce(force, transform.position, radius);
        }
    }

}
