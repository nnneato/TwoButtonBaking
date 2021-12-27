using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPause : MonoBehaviour
{

    public GameObject logicStuff;
    private GameVariables gameVariables;

    private void Awake()
    {
        logicStuff = GameObject.FindWithTag("Logic");
        gameVariables = logicStuff.GetComponent<GameVariables>();
    }

    void OnMouseOver()
    {
        if (gameVariables.gamePlaying == true)
        {
            Debug.Log("hovering");
            gameVariables.PauseGame();
        }
    }    
    void OnMouseExit()
    {
        Debug.Log("hover exit");
        //gameVariables.UnpauseGame();
    }
}
