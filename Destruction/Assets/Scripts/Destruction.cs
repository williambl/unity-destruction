using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    [Header("Game Objects")]
    [Space(2)]
    public GameObject brokenObj;
    public GameObject togetherObj;

    [Space(7)]
    [Header("State")]
    [Space(2)]
    // True if together, false if broken
    public bool together = true;
    //Does it start broken?
    public bool startBroken = false;

    [Space(7)]
    [Header("Breaking on Collision")]
    [Space(2)]
    public bool breakOnCollision = true;
    public float velocityToBreak = 1;

    [Space(7)]
    [Header("Breaking when nothing underneath")]
    [Space(2)]
    public bool breakOnNoSupports = false;
    public float raycastLength = 1f;

    [Space(7)]
    [Header("Sound on break")]
    [Space(2)]
    public bool soundOnBreak = false;
    public AudioClip[] clips;

    //Private vars
    private AudioSource src;

    void Start () {
        //Make sure the right object is active
        togetherObj.SetActive(!startBroken);
        brokenObj.SetActive(startBroken);
        together = !startBroken;

        if (soundOnBreak) {
            SetupSound();
        }
    }
	
    void SetupSound() {
        //Get the audio source or create one
        src = GetComponent<AudioSource>();
        if (src == null) {
            src = gameObject.AddComponent<AudioSource>();
        }

        //Add a random audio clip to it
        src.clip = clips[Random.Range(0, clips.Length-1)];
    }

    // Update is called once per frame
    void Update () {
        /* Broken object should follow unbroken one to prevent them from
         * being in the wrong place when they switch */
        brokenObj.transform.position = togetherObj.transform.position;

        //Make sure the right object is active
        togetherObj.SetActive(together);
        brokenObj.SetActive(!together);

        if (breakOnNoSupports)
            CheckForSupports();
    }

    void CheckForSupports () {
        //Check downwards for supports
        if (!Physics.Raycast(transform.position, Vector3.down, raycastLength))
            Break();
    }

    void OnCollisionEnter(Collision collision) {
        if (!breakOnCollision)
            return;
        //Only break if relative velocity is high enough
        if (collision.relativeVelocity.magnitude > velocityToBreak)
            Break();
    }

    public void Break () {
        together = false;

        //Play the sound
        if (soundOnBreak)
            src.Play();
    }

    public void BreakWithExplosiveForce(float force, float radius = 3) {
        Break();

        //Add the explosive force to each rigidbody
        foreach (Rigidbody rigid in brokenObj.GetComponentsInChildren<Rigidbody>()) {
            rigid.AddExplosionForce(force, transform.position, radius);
        }
    }

}
