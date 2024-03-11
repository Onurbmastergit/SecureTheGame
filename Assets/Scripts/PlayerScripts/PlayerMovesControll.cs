using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovesControll : MonoBehaviour
{
    public float velocidade = 5f;

    private CharacterController characterController;
    GameObject mainCamera;


    void Start()
    {
         mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, movimentoVertical) * velocidade * Time.deltaTime;

        
        characterController.Move(movimento);
        
    }
}
