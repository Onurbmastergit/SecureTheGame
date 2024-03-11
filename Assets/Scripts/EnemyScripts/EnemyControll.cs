using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public float velocidade = 0; // Velocidade de movimento do inimigo

    public bool chegouAoDestino = true; // Indica se o inimigo chegou ao destino de rondagem
    bool rondarArea = true; // Indica se o inimigo está rondando a área
    public bool seguirJogador = false; // Indica se o inimigo está seguindo o jogador

    Vector3 destino; // O destino atual para o qual o inimigo está se movendo
    Rigidbody rb;
    Transform mainCameraTransform; // Referência para a transformada da MainCamera


    private void Start()
    {
        destino = Vector3.zero; // Inicializa o destino como zero
        rb = GetComponent<Rigidbody>(); // Obtém o Rigidbody do inimigo
        
    }

    private void FixedUpdate()
    {
        // Se o inimigo está seguindo o jogador
        if (seguirJogador == false)
        {
            Vector3 positionPlayer = GameObject.FindWithTag("HouseDefender").transform.position; // Obtém a posição do jogador
            transform.position = Vector3.MoveTowards(transform.position, positionPlayer, velocidade * Time.deltaTime); // Move-se em direção ao jogador

            // Olha na direção do jogador
            

            // Define as variáveis de movimento
           
        }
        // Se o inimigo está rondando a área
        if (rondarArea  == false)
        {
            // Se o inimigo chegou ao destino
            if (chegouAoDestino)
            {
                // Define um novo destino aleatório dentro de uma área ao redor do inimigo
                float posicaoX = Random.Range(transform.position.x - 50, transform.position.x + 50);
                float posicaoZ = Random.Range(transform.position.z - 50, transform.position.z + 50);
                destino = new Vector3(posicaoX, transform.position.y, posicaoZ);
                Invoke("DesabilitaChegouAoDestino", 3f); // Invoca o método para desativar a variável de chegada ao destino após 2 segundos
            }

            // Se o inimigo não chegou ao destino
            if (!chegouAoDestino)
            {
                // Move-se em direção ao destino
                transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);

               
            }

            // Se a distância entre o inimigo e o destino for menor que 0.1f, o inimigo chegou ao destino
            if (Vector3.Distance(transform.position, destino) < 0.1f)
            {
                chegouAoDestino = true;
            }
        }
    }
    

    // Método para desativar a variável de chegada ao destino após 2 segundos
    public void DesabilitaChegouAoDestino()
    {
        chegouAoDestino = false; // Desativa a variável de chegada ao destino
        transform.LookAt(mainCameraTransform.position); // Olha na direção do destino
    }

    // Quando algo entra no trigger do inimigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HouseDefender")
        {
            rondarArea = false; // Define que o inimigo não está mais rondando a área
            seguirJogador = true; // Define que o inimigo está seguindo o jogador
        }
    }

    // Quando algo sai do trigger do inimigo
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HouseDefender")
        {
            rondarArea = true; // Define que o inimigo está rondando a área novamente
            seguirJogador = false; // Define que o inimigo não está mais seguindo o jogador
        }
    }
}
