using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    
     public static float movimentoHorizontal;
     public static float movimentoVertical;
   
    void Update()
    {
         movimentoHorizontal = Input.GetAxis("Horizontal");
        if (movimentoHorizontal != 0) 
        {
            Debug.Log("RecebeuInput");
        }
        if (movimentoVertical != 0) 
        {
            Debug.Log("RecebeuInputVertical");
        }
         movimentoVertical = Input.GetAxis("Vertical");
    }
}
