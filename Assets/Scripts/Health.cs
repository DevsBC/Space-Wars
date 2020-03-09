using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este clase define el comportamiento de Health
/// </summary>
public class Health : MonoBehaviour
{
    public GameObject deathParticlesPrefab = null;
    private Transform transform = null;
    public bool shouldBeDestroyedOnDeath = true;

    /// <summary>
    /// Establece y Recupera los valores de la variable serializada _healthPoints
    /// </summary>
    /// <returns>
    /// healthPoints del GameObject 
    /// </returns>
    public float healthPoints { 
        get {
           return _healthPoints; 
        }
        set {
            _healthPoints = value;
            if(_healthPoints <= 0) 
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                if(deathParticlesPrefab != null) 
                {
                    Instantiate(deathParticlesPrefab, transform.position, transform.rotation);
                    if(shouldBeDestroyedOnDeath) 
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            healthPoints = 0;
        }
    }

    [SerializeField]
    private float _healthPoints = 100.0f;
}
