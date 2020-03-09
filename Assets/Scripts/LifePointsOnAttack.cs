using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase recupera la vida del jugador y la actualiza en pantalla
/// </summary>
public class LifePointsOnAttack : MonoBehaviour
{
    private Transform theTransform = null;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        theTransform = GetComponent<Transform>();
        health = theTransform.gameObject.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Accede a la variable estatica y actualizar su valor
        GameController.lifePlayer = (int) health.healthPoints;
    }
}
