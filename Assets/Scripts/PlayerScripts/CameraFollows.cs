using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target; // O objeto que a câmera irá seguir
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento da câmera

    private Vector3 offset; // A distância entre a câmera e o objeto seguido

    void Start()
    {
        offset = transform.position - target.position; // Calcula o offset inicial
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset; // Calcula a posição desejada da câmera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Suaviza o movimento da câmera
            transform.position = smoothedPosition; // Atualiza a posição da câmera
        }
    }
}
