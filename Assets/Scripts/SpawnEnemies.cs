using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase permite instanciar nuevos enemigos en la escena
/// </summary>
public class SpawnEnemies : MonoBehaviour
{
    public float maxRadius = 1.0f;
    public float interval = 5.0f;
    public GameObject[] objectsToSpawn = new GameObject[3];
    private Transform origin = null;

    void Awake()
    {
        origin = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {   
        InvokeRepeating("Spawn", 0.0f, interval);
    }

    /// <summary>
    /// Este metodo instancia un nuevo enemigo
    /// </summary>
    private void Spawn()
    {
        if (origin == null)
            return;

        // Recupera la posicion actual del jugador
        Vector3 spawnPosition = origin.position + Random.onUnitSphere * maxRadius;
        // Establece la posicion al nuevo enemigo
        spawnPosition = new Vector3(spawnPosition.x, 0.0f, spawnPosition.z);

        // Elige aleatoriamente un nuevo enemigo del array
        System.Random random = new System.Random();
        int positionNewEnemy = random.Next(objectsToSpawn.Length);

        // Instancia un nuevo enemigo en la posicion especificada
        Instantiate(objectsToSpawn[positionNewEnemy], spawnPosition, Quaternion.identity);

    }
}
