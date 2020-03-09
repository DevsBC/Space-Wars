using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase define el movimiento de los objetos en la escena
/// </summary>
public class Movement : MonoBehaviour
{
    public Transform transform = null;
    public float maxSpeed = 8.0f;

    void Awake()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * maxSpeed * Time.deltaTime;
        
    }
}
