using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudLocation : MonoBehaviour
{
    public Transform objetoParaSeguir;
    public GameObject objetoHUD;

    // Update is called once per frame
    void Update()
    {
        // Verifica se o transform do objeto a ser seguido e o HUD foram atribuídos
        if (objetoParaSeguir != null && objetoHUD != null)
        {
            // Obtem a posição do objeto a ser seguido
            Vector3 posicaoObjetoSeguir = objetoParaSeguir.position;

            // Atualiza a posição do HUD apenas nos eixos x e z, mantendo a posição y
            objetoHUD.transform.position = new Vector3(posicaoObjetoSeguir.x, objetoHUD.transform.position.y, posicaoObjetoSeguir.z);
        }
    }
}
