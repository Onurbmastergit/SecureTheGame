using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCollider : MonoBehaviour
{
    public bool buildAttack = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Build"))
        { 
            Debug.Log("Construção");
            buildAttack = true;
        }
        else 
        {
            Debug.Log("Não Construção");
            buildAttack = false;
        }
    }
}
