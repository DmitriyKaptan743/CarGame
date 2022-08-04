using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Скорость движения в стороны")]
        public float StrafeSpeed = 10f;
    
    private Rigidbody _rigidbody;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float sideforce = Input.GetAxis("Horizontal") * StrafeSpeed;

        _rigidbody.AddForce(sideforce, 0f, 0f);
    }

    void Update()
    {
      
    }
}
