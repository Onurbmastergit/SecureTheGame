using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo
    public Transform spawnPoint; // Ponto de spawn do inimigo

    public SpawnerControll spawnerControl;

    public int tamanhoDaHorda;
    public int idSpawner;
    public bool canSpawn;
    int InimigosPorSpawn;

   
   

    void Update()
    {
        if (SpawnerControll.numeroSorteado == idSpawner && canSpawn == true )
        {
            SpawnEnemy();
        }
        if (canSpawn == false) 
        {
            Invoke("EnableSpawn", spawnerControl.spawnInterval);
        }
       
    }
    void EnableSpawn() 
    {
        canSpawn = true;
    } 

    void  SpawnEnemy()
    {
        Debug.Log($"Spawn{idSpawner}");
        if (canSpawn == true) 
        {
            for (int i = 0; i < tamanhoDaHorda; i++)
            {
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                InimigosPorSpawn++;
                
            }
               spawnerControl.GetComponent<SpawnerControll>().TimerSpawn();
               canSpawn = false;
            
        }
        
        
    }
}
