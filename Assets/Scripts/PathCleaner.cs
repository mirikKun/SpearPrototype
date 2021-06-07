using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<ObstacleBlow>()?.Charge();
    }
}
