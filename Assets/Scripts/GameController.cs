using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Este clase define las interfaces de usuario
/// </summary>
public class GameController : MonoBehaviour
{

    public static int score = 0;
    public static int lifePlayer = 0;

    public string scorePrefix = "Score: ";
    public string lifePrefix = "Life: ";

    public Text scoreText = null;
    public Text gameOverText = null;
    public Text lifeText = null;
    
    public static GameController gameController = null;

    /// <summary>
    /// Este metodo se hereda de MonoBehaviour y es el primer metodo que se inicia 
    /// al crearse un nuevo GameObject
    /// </summary>
    void Awake()
    {
        gameController = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
            
        if (scoreText != null)
        {
            scoreText.text = scorePrefix + score.ToString();
            lifeText.text = lifePrefix + lifePlayer.ToString();
        }
    }

    /// <summary>
    /// Este metodo se llama cuando el jugador ha muerto
    /// </summary>
    public static void GameOver()
    {
        if(gameController.gameOverText != null)
        {
            gameController.gameOverText.gameObject.SetActive(true);
        }
    }
}
