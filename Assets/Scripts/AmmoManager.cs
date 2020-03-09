using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase define el controlador de Ammo en la escena 
/// </summary>
public class AmmoManager : MonoBehaviour
{
    public GameObject ammoPrefab = null;
    public int poolSize = 100;
    // Encolar objetos nos permite reutilizarlos y optimizar el rendimiento
    public Queue<Transform> ammoQueue = new Queue<Transform>();
    private GameObject[] ammoArray;
    public static AmmoManager ammoManager = null;

    /// <summary>
    /// Este metodo se hereda de MonoBehaviour y es el primer metodo que se inicia 
    /// al crearse un nuevo GameObject
    /// </summary>
    void Awake()
    {
        // Verifica que no exista mas un ammoManager
        if (ammoManager != null)
        {
            Destroy(GetComponent<AmmoManager>());
            return;
        }

        ammoManager = this;

        InstantiateAmmo();
    }

    /// <summary>
    /// Instancia un GameObject Ammo en la escena
    /// </summary>
    /// <returns>
    /// GameObject Ammo 
    /// </returns>
    public static Transform SpawnAmmo(Vector3 position, Quaternion rotation)
    {
        Transform ammo = ammoManager.ammoQueue.Dequeue();
        ammo.gameObject.SetActive(true);
        ammo.position = position;
        ammo.localRotation = rotation;
        ammoManager.ammoQueue.Enqueue(ammo);
        return ammo;
    }

    /// <summary>
    /// Instancia un prefab de Ammo y lo agrega en cada iteracion en el array de Queue<Transform>
    /// El tamaño de la lista corresponde a poolSize
    /// </summary>
    private void InstantiateAmmo()
    {
        ammoArray = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            GameObject ammo = Instantiate(ammoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            Transform transform = ammo.GetComponent<Transform>();
            transform.parent = GetComponent<Transform>();

            ammoQueue.Enqueue(transform);
            ammo.SetActive(false);
            ammoArray[i] = ammo;
        }
    }
}
