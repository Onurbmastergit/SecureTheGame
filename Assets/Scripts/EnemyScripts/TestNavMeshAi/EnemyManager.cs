using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
     public NavMeshAgent agent;
    public DetectionCollider buildOn;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

}
