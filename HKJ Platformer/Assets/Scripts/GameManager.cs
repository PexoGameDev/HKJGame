using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] ingredientsPrefabs;
    public Vector3[] spawnOrigins;

    void Start()
    {
        InvokeRepeating("SpawnPieces",2f,1.2f);
    }

    void Update()
    {
        
    }

    void SpawnPieces()
    {
        int randOrigin = Random.Range(0, spawnOrigins.Length);
        Instantiate(ingredientsPrefabs[Random.Range(0, ingredientsPrefabs.Length)], spawnOrigins[randOrigin], Quaternion.identity);
        Instantiate(ingredientsPrefabs[Random.Range(0, ingredientsPrefabs.Length)], spawnOrigins[(randOrigin+1)%spawnOrigins.Length], Quaternion.identity);
    }
}
