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
        }
      
    }



  
}
