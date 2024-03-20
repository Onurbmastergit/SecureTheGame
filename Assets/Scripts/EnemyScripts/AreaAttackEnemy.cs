using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaAttackEnemy : MonoBehaviour
{
   void OnTriggerEnter(Collider collider)
   {
        if(collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerStatus>().ReceberDano(10);
        }
   }
}
