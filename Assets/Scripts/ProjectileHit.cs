using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class ProjectileHit : MonoBehaviour
{
    [SerializeField] private float scalingTime;
    [SerializeField] private float scaling;
    [SerializeField] private GameObject boom;
    private float _time;
    private Transform _transform;
    private Rigidbody _rigidbody;
    private SphereCollider _capsuleCollider;
    private Shooter _shooter;
    private void Start()
    {
        _shooter = FindObjectOfType<Shooter>();
        _capsuleCollider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<ObstacleBlow>())
        {
            other.gameObject.GetComponent<ObstacleBlow>().Charge();
            Explosion();
            
        }
        else if (other.gameObject.GetComponent<TargetZoneEnter>())
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        _capsuleCollider.isTrigger = true;
        _rigidbody.isKinematic = true;
        _transform.DOScale( _transform.localScale * scaling, scalingTime);
        _shooter.ReactToHit(_transform.position);
        Destroy(gameObject,scalingTime);
    }
    private void OnDestroy()
    {
        Instantiate(boom, transform.position, Quaternion.identity);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        other.gameObject.GetComponent<ObstacleBlow>()?.Charge();
    }
}