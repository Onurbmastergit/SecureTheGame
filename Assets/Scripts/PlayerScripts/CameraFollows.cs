using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
  public Transform target; // O objeto que a câmera irá seguir
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento da câmera
    public float rotationSensitivity = 2.0f; // Sensibilidade de rotação da câmera

    private Vector3 offset; // A distância entre a câmera e o objeto seguido
    private bool rotating = false; // Flag para controlar se a câmera está rotacionando ou não

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
            if (target == null)
            {
                Debug.LogError("CameraFollows: O objeto com a tag 'Player' não foi encontrado.");
                return;
            }
        }
        
        offset = transform.position - target.position; // Calcula o offset inicial
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula a posição desejada da câmera
            Vector3 desiredPosition = target.position + offset;
            
            // Suaviza o movimento da câmera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            
            // Atualiza a posição da câmera
            transform.position = smoothedPosition;

            // Se o botão do mouse 0 estiver pressionado, rotaciona a câmera
            if (Input.GetMouseButton(0))
            {
                RotateCamera();
            }

            // Faz a câmera olhar para o alvo (o jogador)
            transform.LookAt(target);
        }
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSensitivity;

    // Rotaciona a câmera em torno do jogador apenas horizontalmente
        transform.RotateAround(target.position, Vector3.up, mouseX);
    }
}
