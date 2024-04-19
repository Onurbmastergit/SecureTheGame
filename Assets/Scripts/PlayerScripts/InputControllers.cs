using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllers : MonoBehaviour
{
  public bool Attack;
  public bool Run;
  public bool build;
            
  
  public float movimentoHorizontal;
  public float movimentoVertical;
  public int hand;  

  void Update()
  {
    movimentoHorizontal = Input.GetAxis("Horizontal");

    movimentoVertical = Input.GetAxis("Vertical");

    build = Input.GetKeyDown(KeyCode.B);

    Attack = Input.GetKey(KeyCode.Mouse1);

    Run = Input.GetKey(KeyCode.LeftShift);

    VerificarTeclado();
  }

    void VerificarTeclado() 
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;

            if (keyPressed.Length == 1 && char.IsDigit(keyPressed[0]))
            {
                hand = int.Parse(keyPressed);

               
               
            }
        }
    }  
}
