using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase define el comportamiento de Ammo en la escena
/// </summary>
public class Ammo : MonoBehaviour
{
    public float damage = 100.0f;
    public float lifeTime = 2.0f;

    /// <summary>
    /// Este metodo se hereda de MonoBehaviour y se llama cuando un GameObject
    /// es activado en la escena
    /// </summary>
    void OnEnable()
    {
        /// <summary>
        /// Este metodo cancela cualquier invocacion hecha por otra instancia
        /// </summary>
        CancelInvoke();

        /// <summary>
        /// Envia un mensaje para llamar al metodo local Die despues del tiempo
        /// establecido en lifeTime
        /// </summary>
        Invoke("Die", lifeTime);
    }

    /// <summary>
    /// Este metodo detecta cuando un objeto colisiona con otro objeto en la escena
    /// </summary>
    private void OnTriggerEnter(Collider collider)
    {
        Health health = collider.gameObject.GetComponent<Health>();
        if (health == null)
            return;
        // Recupera el componente para restarle healthPoints
        health.healthPoints -= damage;
    }

    void Die()
    {
        /// <summary>
        /// Este metodo desactiva un GameObject en la escena
        /// </summary>
        gameObject.SetActive(false);
    }

}
