using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{

    public Animator extruder;
    public GameObject logicStuff;
    private GameVariables gameVariables;


    // Start is called before the first frame update
    void Start()
    {
        logicStuff = GameObject.FindWithTag("Logic");
        gameVariables = logicStuff.GetComponent<GameVariables>();
    }

    void Update()
    {
        // not playing
        if (Input.GetKeyDown("z") && gameVariables.gamePlaying != true)
        {
            gameVariables.StartGame();
            Debug.Log("Game started");
        }
        // playing, not paused
        if (Input.GetKeyDown("z") && gameVariables.gamePaused != true && gameVariables.gamePlaying == true)
        {
            gameVariables.DropBatter();
            extruder.SetTrigger("extrude");

        }
        // playing and paused
        if (Input.GetKeyDown("z") && gameVariables.gamePaused == true && gameVariables.gamePlaying == true)
        {
            // Z to continue when paused
            gameVariables.UnpauseGame();
            Debug.Log("Game continued");
        }
        
        if (Input.GetKeyDown("x") && gameVariables.gamePaused != true && gameVariables.gamePlaying == true)
        {
            extruder.SetTrigger("extrude");
            gameVariables.DropBatter();
            gameVariables.DropBatter();
            gameVariables.DropBatter();
            gameVariables.DropBatter();
            gameVariables.DropBatter();            

        }
        if (Input.GetKeyDown("x") && gameVariables.gamePaused == true && gameVariables.gamePlaying == true)
        {
            // Z to end when paused
            gameVariables.EndGame();
            Debug.Log("Game ended");
        }
    }

}
