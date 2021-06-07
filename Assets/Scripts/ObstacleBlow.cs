using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlow : MonoBehaviour
{
    [SerializeField] private Material preBlowMaterial;
    [SerializeField] private float timeToBlow;
    [SerializeField] private GameObject boom;

    public void Charge()
    {
        StartCoroutine(WaitForBlow());
        GetComponentInChildren<MeshRenderer>().material = preBlowMaterial;
    }

    private IEnumerator WaitForBlow()
    {
        yield return new WaitForSeconds(timeToBlow);
        Blow();
    }

    private void Blow()
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}