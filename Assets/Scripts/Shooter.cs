using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float bulletSpeed=10;
    [SerializeField] private float bulletCreationSpeed=100/15f;
    [SerializeField] private float sphereMaxSize=100;
    [SerializeField] private float sphereMinSize=5;
    [SerializeField] private float projectileStartSize = 5f;
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float rechargeTime=2;
    [SerializeField] private PathController pathController;
    [SerializeField] private Rigidbody pathCleaner;
    private float _distanceToHitPoint=0.5f;
    private float _timer;
    private Transform _transform;
    private Vector3 _direction;
    private Rigidbody _currentProjectile;
    private Rigidbody _rigidbody;
    private float _sphereSize;
    private float _distanceToHit;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _sphereSize = sphereMaxSize;
        _transform = transform;
        _direction = target.position - _transform.position;
        _direction = new Vector3(_direction.x, 0, _direction.z).normalized;
        _transform.LookAt(target);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")&&_timer<Time.time&&Time.timeScale!=0)
        {
            GameManager.GM.TryAttempt();
            CreatProjectile();
        }
    }

    
    private void CreatProjectile()
    {
        _currentProjectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        StartCoroutine(ProjectileGrowing());
    }
    public void ReactToHit(Vector3 hitPoint)
    {
        _distanceToHit = Vector3.Distance(hitPoint, _transform.position);
        PathCleanerShoot(hitPoint);
        MoveToHit(hitPoint);
    }

    private void MoveToHit(Vector3 hitPoint)
    {
        _transform.DOMove(_transform.position+_direction*(_distanceToHit-_distanceToHitPoint), rechargeTime);
    }
    private void PathCleanerShoot(Vector3 hitPoint)
    {
        Rigidbody newPathCleaner = Instantiate(pathCleaner, shootPoint.position, Quaternion.identity);
        newPathCleaner.transform.localScale = _transform.localScale;
        newPathCleaner.DOMove(_transform.position+_direction*(_distanceToHit-_distanceToHitPoint), rechargeTime / 2);
        Destroy(newPathCleaner.gameObject, rechargeTime / 2);
    }
    private IEnumerator ProjectileGrowing()
    {
        float lastWidth = _sphereSize / sphereMaxSize;
        float projectileNewScale = projectileStartSize;
        _sphereSize -= projectileNewScale;
        _rigidbody.isKinematic = false;
        while (Input.GetButton("Fire1"))
        {
            projectileNewScale += Time.deltaTime * bulletCreationSpeed;
            _sphereSize -= Time.deltaTime * bulletCreationSpeed;
            
            if (_sphereSize < sphereMinSize)
            {
                GameManager.GM.Lose();
            }
            _currentProjectile.transform.localScale = Vector3.one*projectileNewScale/sphereMaxSize;
            _transform.localScale=Vector3.one*_sphereSize/sphereMaxSize;
            yield return null;
        }
        _rigidbody.isKinematic = true;
        _timer = Time.time + rechargeTime;
        _currentProjectile.useGravity = false;
        ShootProjectile();
        while (_timer>Time.time)
        {
            lastWidth = Mathf.Lerp(lastWidth, _sphereSize / sphereMaxSize, Time.deltaTime * rechargeTime);
            pathController.PathSetup( lastWidth); 
           yield return null;
        }
    }
    private void ShootProjectile()
    {
        _currentProjectile.velocity=_direction*bulletSpeed;
    }
}
