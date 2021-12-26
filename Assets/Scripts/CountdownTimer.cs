using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CountdownTimer : MonoBehaviour
{

    public float currentTime;
    public float startingTime = 60f;

    public TextMeshProUGUI timerText;

    public GameObject logicStuff;
    private GameVariables gameVariables;
    private float speedUp = 0;


    void Start()
    {
        currentTime = startingTime;
        logicStuff = GameObject.FindWithTag("Logic");
        gameVariables = logicStuff.GetComponent<GameVariables>();
    }

    void Update()
    {
        if (gameVariables.gamePaused != true && gameVariables.gamePlaying == true)
        {
            currentTime -= 1 * Time.deltaTime;
            speedUp += 1 * Time.deltaTime;
            timerText.SetText(currentTime.ToString("0"));

            if (speedUp >= 15)
            {
                gameVariables.IncreaseSpeed();
                speedUp = 0;
            }

        }

        if (currentTime <= 0)
        {
            gameVariables.EndGame();
        }
    }
}
