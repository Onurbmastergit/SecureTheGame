using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public float velocidade = 0; // Velocidade de movimento do inimigo

    public bool chegouAoDestino = true; // Indica se o inimigo chegou ao destino de rondagem
    bool rondarArea = true; // Indica se o inimigo est� rondando a �rea
    public bool seguirJogador = false; // Indica se o inimigo est� seguindo o jogador

    Vector3 destino; // O destino atual para o qual o inimigo est� se movendo
    Rigidbody rb;
    Transform mainCameraTransform; // Refer�ncia para a transformada da MainCamera


    private void Start()
    {
        destino = Vector3.zero; // Inicializa o destino como zero
        rb = GetComponent<Rigidbody>(); // Obt�m o Rigidbody do inimigo
        
    }

    private void FixedUpdate()
    {
        // Se o inimigo est� seguindo o jogador
        if (seguirJogador == false)
        {
            Vector3 positionPlayer = GameObject.FindWithTag("HouseDefender").transform.position; // Obt�m a posi��o do jogador
            transform.position = Vector3.MoveTowards(transform.position, positionPlayer, velocidade * Time.deltaTime); // Move-se em dire��o ao jogador

            // Olha na dire��o do jogador
            

            // Define as vari�veis de movimento
           
        }
        // Se o inimigo est� rondando a �rea
        if (rondarArea  == false)
        {
            // Se o inimigo chegou ao destino
            if (chegouAoDestino)
            {
                // Define um novo destino aleat�rio dentro de uma �rea ao redor do inimigo
                float posicaoX = Random.Range(transform.position.x - 50, transform.position.x + 50);
                float posicaoZ = Random.Range(transform.position.z - 50, transform.position.z + 50);
                destino = new Vector3(posicaoX, transform.position.y, posicaoZ);
                Invoke("DesabilitaChegouAoDestino", 3f); // Invoca o m�todo para desativar a vari�vel de chegada ao destino ap�s 2 segundos
            }

            // Se o inimigo n�o chegou ao destino
            if (!chegouAoDestino)
            {
                // Move-se em dire��o ao destino
                transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);

               
            }

            // Se a dist�ncia entre o inimigo e o destino for menor que 0.1f, o inimigo chegou ao destino
            if (Vector3.Distance(transform.position, destino) < 0.1f)
            {
                chegouAoDestino = true;
            }
        }
    }
    

    // M�todo para desativar a vari�vel de chegada ao destino ap�s 2 segundos
    public void DesabilitaChegouAoDestino()
    {
        chegouAoDestino = false; // Desativa a vari�vel de chegada ao destino
        transform.LookAt(mainCameraTransform.position); // Olha na dire��o do destino
    }

    // Quando algo entra no trigger do inimigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HouseDefender")
        {
            rondarArea = false; // Define que o inimigo n�o est� mais rondando a �rea
            seguirJogador = true; // Define que o inimigo est� seguindo o jogador
        }
    }

    // Quando algo sai do trigger do inimigo
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "HouseDefender")
        {
            rondarArea = true; // Define que o inimigo est� rondando a �rea novamente
            seguirJogador = false; // Define que o inimigo n�o est� mais seguindo o jogador
        }
    }
}
