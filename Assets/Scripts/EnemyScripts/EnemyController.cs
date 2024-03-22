using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 lastPosition;
    public float velocidade = 0; // Velocidade de movimento do inimigo

    public bool die = false;
    //public Animator animator;
    Vector3 destino; // O destino atual para o qual o inimigo está se movendo
    Rigidbody rb;
    bool movingLeft;
    bool movingRight;
    float movementDirection;

    private void Start()
    {
        destino = Vector3.zero; // Inicializa o destino como zero
        rb = GetComponent<Rigidbody>(); // Obtém o Rigidbody do inimigo
        lastPosition = transform.position;
        //animator.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(die == false)
        {
        movementDirection = transform.position.x - lastPosition.x;
        movingRight = movementDirection > 0;
        movingLeft = movementDirection < 0;
        //animator.SetBool("Left" , movingLeft );
        //animator.SetBool("Right" , movingRight);
        Vector3 positionPlayer = GameObject.FindWithTag("HouseDefender").transform.position; // Obtém a posição do jogador
        positionPlayer.y = transform.position.y; // Mantém a altura do jogador igual à do inimigo
        transform.position = Vector3.MoveTowards(transform.position, positionPlayer, velocidade * Time.deltaTime); // Move-se em direção ao jogador
        }
        else if(die == true)
        {
            Invoke("DestruirCorpo" , 1.5f);
        } 
            
       
    }
     void DestruirCorpo()
     {
        Destroy(gameObject);
     }
    
}