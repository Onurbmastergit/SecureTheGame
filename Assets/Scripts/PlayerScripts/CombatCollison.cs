using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatCollison : MonoBehaviour
{

  

    void OnTriggerEnter(Collider collider)
    {

        if(collider.TryGetComponent<EnemyStatus>(out EnemyStatus enemyStatus))
        {
            enemyStatus.ReceberDano(5);
            Debug.Log("Bateu 2");
        }
        if (collider.CompareTag("Zombie")) 
        {
            collider.GetComponent<EnemyStatus>().ReceberDano(6);
            Debug.Log("Bateu");
        }
    }



  
}
