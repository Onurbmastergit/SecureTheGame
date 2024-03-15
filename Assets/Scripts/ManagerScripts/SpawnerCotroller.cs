using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCotroller: MonoBehaviour
{
public GameObject inimigoPrefab;
    public int quantidadeMaxima = 5;

    private bool spawning = false;
    public Transform spawnPoint; // Transform para o ponto de spawn dos inimigos

    public bool EstaAtivo()
    {
        return spawning;
    }

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
        int quantidadeTotalSpawned = 0;

        while (spawning && quantidadeTotalSpawned < quantidadeMaxima)
        {
            int quantidade = Random.Range(1, quantidadeMaxima - quantidadeTotalSpawned + 1);
            SpawnInimigos(quantidade);
            quantidadeTotalSpawned += quantidade;
            yield return new WaitForSeconds(1f); // Espera um segundo antes de tentar spawnar novamente
        }

        // Desativa o spawner após spawna a quantidade definida de inimigos
        DesativarSpawner();
    }

    void SpawnInimigos(int quantidade)
    {
        Debug.Log("Spawning " + quantidade + " inimigos...");
        Vector3 spawnPointPosition = spawnPoint.position;
        Vector3 spawnPointSize = spawnPoint.localScale; // Usamos a escala do objeto para determinar o tamanho da área

        for (int i = 0; i < quantidade; i++)
        {
            Vector3 randomPosition = GetRandomSpawnPositionWithinBounds(spawnPointPosition, spawnPointSize);
            Instantiate(inimigoPrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPositionWithinBounds(Vector3 center, Vector3 size)
    {
        // Calcula uma posição aleatória dentro do limite do transform
        float randomX = Random.Range(center.x - size.x / 2f, center.x + size.x / 2f);
        float randomY = Random.Range(center.y - size.y / 2f, center.y + size.y / 2f);
        float randomZ = Random.Range(center.z - size.z / 2f, center.z + size.z / 2f);

        return new Vector3(randomX, randomY, randomZ);
    }
}
