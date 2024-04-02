using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllers : MonoBehaviour
{
  public bool Attack;
  public bool Run;
  public float movimentoHorizontal;
  public float movimentoVertical;

  void Update()
  {
    movimentoHorizontal = Input.GetAxis("Horizontal");
    movimentoVertical = Input.GetAxis("Vertical");

    Attack = Input.GetKey(KeyCode.Mouse1);
    Run = Input.GetKey(KeyCode.LeftShift);
  }
}
