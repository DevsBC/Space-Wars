using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase define el comportamiento del enemigo al encontrarse con el jugador
/// </summary>
public class FaceToObject : MonoBehaviour
{
    public Transform objectToFollow = null;
    private Transform transform = null;
    public bool followPlayer = true;

    /// <summary>
    /// Este metodo se hereda de MonoBehaviour y es el primer metodo que se inicia 
    /// al crearse un nuevo GameObject
    /// </summary>
    void Awake()
    {
        transform = GetComponent<Transform>();

        if (!followPlayer)
            return;

        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");

        if (thePlayer != null)
        {
            objectToFollow = thePlayer.GetComponent<Transform>();

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (objectToFollow == null)
            return;

        // Cambia la direccion de un enemigo al encontrarse con el jugador
        Vector3 directionToFollow = objectToFollow.position - transform.position;
        if(directionToFollow != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(directionToFollow.normalized, Vector3.up);
        }
    }
}
