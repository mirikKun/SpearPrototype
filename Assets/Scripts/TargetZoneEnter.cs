using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZoneEnter : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.GetComponent<Shooter>())
      {
         GameManager.GM.Victory();
      }
   }
}
