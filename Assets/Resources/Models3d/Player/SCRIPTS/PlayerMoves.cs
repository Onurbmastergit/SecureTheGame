using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public float velocidade = 5f;
    public float suavidadeRotacao = 5f; // Ajuste este valor para controlar a suavidade da rotação
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private InputControllers inputControllers;
    public float movimentoHorizontal; 
    public float movimentoVertical;

    void Start()
    {
        inputControllers = GetComponent<InputControllers>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        movimentoHorizontal = inputControllers.movimentoHorizontal;
        movimentoVertical = inputControllers.movimentoVertical;

       

        Vector3 movimento = new Vector3(movimentoHorizontal, 0f, movimentoVertical);

        if (movimento.magnitude > 1f)
        {
            movimento.Normalize();
        }
        
        movimento *= velocidade * Time.deltaTime;

        if(inputControllers.Run)
        {
            movimento *= 2;
        }

        characterController.Move(movimento);

        // Verifica se há movimento antes de virar o jogador
        if (movimento != Vector3.zero)
        {
            // Calcula a rotação para a direção do movimento
            Quaternion novaRotacao = Quaternion.LookRotation(movimento);
            // Interpola suavemente entre a rotação atual e a nova rotação
            Quaternion rotacaoSuave = Quaternion.Lerp(transform.rotation, novaRotacao, suavidadeRotacao * Time.deltaTime);
            // Aplica a rotação ao jogador, mas mantém a rotação vertical original
            transform.rotation = Quaternion.Euler(0f, rotacaoSuave.eulerAngles.y, 0f);
        }
    }
}