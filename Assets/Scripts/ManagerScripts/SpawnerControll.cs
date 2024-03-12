using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class SpawnerControll : MonoBehaviour
{
    public static int numeroSorteado;
    public static bool sortear = true;
    public float spawnInterval;
    int numeroAsortear;    

    private void Start()
    {
        SortearNumero();
    }
    private void Update()
    {
        numeroSorteado = numeroAsortear;
        Debug.Log($"numero sorteado é {numeroSorteado}");
    }

    public  void TimerSpawn() 
    {
        Invoke("SortearNumero", spawnInterval);
    }
   
    public void SortearNumero() 
    {
        numeroAsortear = Random.Range(1, 7);
    }
}
