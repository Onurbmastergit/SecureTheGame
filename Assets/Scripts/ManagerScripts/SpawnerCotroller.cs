using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCotroller: MonoBehaviour
{
    public GameObject inimigoPrefab;
    public int quantidadeMaxima = 5;

    private bool spawning = false;
    public Transform spawnPoint; // Transform para o ponto de spawn dos inimigos

    public void AtivarSpawner()
    {
        spawning = true;
        StartCoroutine(SpawnLoop());
    }

    public void DesativarSpawner()
    {
        spawning = false;
    }

    private IEnumerator SpawnLoop()
    {
        while (spawning)
        {
            int quantidade = Random.Range(1, quantidadeMaxima + 1);
            SpawnInimigos(quantidade);
            yield return new WaitForSeconds(1f); // Espera um segundo antes de tentar spawnar novamente
        }
    }

    void SpawnInimigos(int quantidade)
    {
        Debug.Log("Spawning " + quantidade + " inimigos...");
        for (int i = 0; i < quantidade; i++)
        {
            Instantiate(inimigoPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
