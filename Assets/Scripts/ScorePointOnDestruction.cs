using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase lleva el conteo de los enemigos eliminados por el jugador
/// </summary>
public class ScorePointOnDestruction : MonoBehaviour
{
    public int scorePoints = 200;

    void OnDestroy()
    {
        GameController.score += scorePoints;
    }

}
