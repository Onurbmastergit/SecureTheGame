using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target; // O objeto que a c�mera ir� seguir
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o do movimento da c�mera

    private Vector3 offset; // A dist�ncia entre a c�mera e o objeto seguido

    void Start()
    {
        offset = transform.position - target.position; // Calcula o offset inicial
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset; // Calcula a posi��o desejada da c�mera
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Suaviza o movimento da c�mera
            transform.position = smoothedPosition; // Atualiza a posi��o da c�mera
        }
    }
}
