using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public SpawnerCotroller[] spawners; // Array de todos os spawners

    public float intervaloDeAtivacaoMinimo = 10f;
    public float intervaloDeAtivacaoMaximo = 20f;

    private void Start()
    {
        // Começa o processo de ativação dos spawners
        StartCoroutine(GerenciarAtivacaoSpawners());
    }

    private IEnumerator GerenciarAtivacaoSpawners()
    {
        while (true)
        {
            int sorteio = Random.Range(0, 2); // sorteia um número entre 0 e 1
            if (sorteio == 0)
            {
                // Ativa o primeiro spawner da lista
                spawners[0].AtivarSpawner();
            }
            else
            {
                // Desativa o primeiro spawner da lista
                spawners[0].DesativarSpawner();
            }

            // Espera um tempo aleatório antes de ativar ou desativar outro spawner
            float tempoDeEspera = Random.Range(intervaloDeAtivacaoMinimo, intervaloDeAtivacaoMaximo);
            yield return new WaitForSeconds(tempoDeEspera);
        }
    }
}
