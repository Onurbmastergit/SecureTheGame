using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    private Transform point;
    
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();

        point = GameObject.FindWithTag("HouseDefender").transform;
    }

   
    void Update()
    {
        if (enemyManager.buildOn.buildAttack == true) 
        {
            enemyManager.agent.SetDestination(point.position);
        }
        
    }
}
