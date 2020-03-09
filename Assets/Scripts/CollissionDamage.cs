using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase se aplica a los enemigos y permite hacer daño al jugador al hacer colision con el.
/// </summary>
public class CollissionDamage : MonoBehaviour
{
    public float damagePoints = 10.0f;

    /// <summary>
    /// Este metodo detecta cuando un objeto se mantiene dentro de los limites con otro objeto en la escena
    /// </summary>
    void OnTriggerStay(Collider collider)
    {
        Health health = collider.gameObject.GetComponent<Health>();
        if (health == null)
            return;

        health.healthPoints -= damagePoints * Time.deltaTime;
    }
}
