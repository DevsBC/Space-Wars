using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se aplica al jugador y delimita las zonas donde el jugador puede moverse
/// </summary>
public class ControlLimits : MonoBehaviour
{
    private Transform transform = null;
    public Vector2 horizontalRange = Vector2.zero;
    public Vector2 verticalRange = Vector2.zero;

    /// <summary>
    /// Este metodo se hereda de MonoBehaviour y es el primer metodo que se inicia 
    /// al crearse un nuevo GameObject
    /// </summary>
    void Awake()
    {
        transform = GetComponent<Transform>();
    }

    /// <summary>
    /// Este metodo se hereda de MonoBehaviour y se llama despues de Update()
    /// </summary>
    void LateUpdate()
    {
        // Establece un limite en los bordes de la escena
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, horizontalRange.x, horizontalRange.y),
            transform.position.y,
            Mathf.Clamp(transform.position.z, verticalRange.x, verticalRange.y)
        );
    }

}
