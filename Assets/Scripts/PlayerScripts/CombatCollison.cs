using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatCollison : MonoBehaviour
{



    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<EnemyController>() != null)
        {
            Debug.Log("Atingiu o inimigo");
            collider.GetComponent<EnemyController>().animator.SetBool("Die" , true);
            collider.GetComponent<EnemyController>().die = true;
        }
    }



  
}
