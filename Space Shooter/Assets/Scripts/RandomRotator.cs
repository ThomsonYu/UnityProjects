using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;

    private Rigidbody rb;

    //Random.insideUnitSphere gives us a random Vector 3 value which we can apply for the rb angular velocity.
    //Each of the vector 3 values will be randomized individually
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
