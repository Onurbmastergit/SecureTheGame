using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        mainCamera = Camera.main.gameObject; // Obter a câmera principal
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", movimentoHorizontal);
        animator.SetFloat("InputY", movimentoVertical);
        
       
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, movimentoVertical);

        if (movimento.magnitude > 1f)
        {
            movimento.Normalize();
        }
        

        movimento *= velocidade * Time.deltaTime;

         if(Input.GetKey(KeyCode.LeftShift))
        {
            movimento = movimento * 2;
        }

        characterController.Move(movimento);

        // Faz o jogador olhar para a câmera
        transform.LookAt(mainCamera.transform.position);
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
