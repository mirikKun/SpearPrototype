using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCreation : MonoBehaviour
{
    [SerializeField] private ParticleSystem sparks;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Vector3.Magnitude(_rigidbody.velocity) > 0.1f)
        {
            Destroy(sparks);
            Destroy(GetComponent<ProjectileCreation>());
        }
    }
}
