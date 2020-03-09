﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase elimina un objeto en la escena despues del tiempo establecido
/// </summary>
public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", destroyTime);    
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
