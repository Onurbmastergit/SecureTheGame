using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovesControll : MonoBehaviour
{
  public float velocidade = 5f;
  public Animator animator;

    private CharacterController characterController;
    private GameObject mainCamera;
    public Collider attackCollider;
   
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", movimentoHorizontal);
        animator.SetFloat("InputY", movimentoVertical);

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetBool("Attack" , true);
        }
        else
        {
            animator.SetBool("Attack" , false);
        }
        
        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, movimentoVertical);

        // Transforma o movimento local em global, baseado na rotação da câmera
       

        // Normaliza o movimento para manter a mesma velocidade diagonal
        if (movimento.magnitude > 1f)
        {
            movimento.Normalize();
        }

        // Aplica a velocidade e o tempo para o movimento
        movimento *= velocidade * Time.deltaTime;

        // Move o personagem na direção desejada
        characterController.Move(movimento);

        // Se desejar verificar as direções:
    }
     public void EnableCollison()
   {
        attackCollider.enabled = true;
   }
   public void DisableCollison()
   {
        attackCollider.enabled = false;
   }
}
