using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField] private float timeToDestroy=2f;
    void Start()
    {
        Destroy(gameObject,timeToDestroy);
    }
}
