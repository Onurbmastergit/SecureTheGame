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
            // Sorteia um índice aleatório dentro do tamanho da lista de spawners
            int indiceSpawner = Random.Range(0, spawners.Length);

            // Verifica se o spawner está ativado, se estiver, desativa-o após spawnar a quantidade definida
            if (spawners[indiceSpawner].EstaAtivo())
            {
                spawners[indiceSpawner].DesativarSpawner();
                yield return new WaitForSeconds(1f); // Aguarda 1 segundo para desativar o spawner
            }

            // Ativa o spawner selecionado
            spawners[indiceSpawner].AtivarSpawner();

            // Espera um tempo aleatório antes de ativar outro spawner
            float tempoDeEspera = Random.Range(intervaloDeAtivacaoMinimo, intervaloDeAtivacaoMaximo);
            yield return new WaitForSeconds(tempoDeEspera);
        }
    }
}
