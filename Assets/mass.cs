using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mass1 : MonoBehaviour {
    public float mass;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 20f;
    }
    
}
