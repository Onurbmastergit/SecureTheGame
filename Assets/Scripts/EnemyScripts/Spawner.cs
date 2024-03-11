using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo
    public Transform spawnPoint; // Ponto de spawn do inimigo
    public float spawnInterval = 3f; // Intervalo de spawn em segundos

 

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            
                // Instancia um inimigo no ponto de spawn
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            
            // Espera o intervalo de spawn antes de instanciar o próximo inimigo
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
