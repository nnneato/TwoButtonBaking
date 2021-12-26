using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanInGoal : MonoBehaviour
{

    public Animator ovenLight;
    public GameObject logicStuff;
    private GameVariables gameVariables;

    private void Start()
    {
        logicStuff = GameObject.FindWithTag("Logic");
        gameVariables = logicStuff.GetComponent<GameVariables>();
    }

    // Use to mark who has reached the goal
    private void OnTriggerEnter(Collider other)
    {

        GameObject panObject = other.gameObject;
        Transform[] childTransforms = other.GetComponentsInChildren<Transform>();
        Transform batter = childTransforms[1];


        if (panObject.tag == "Silver")
        {
            if (batter.localScale.y != 1f)
            {
                ovenLight.SetTrigger("incorrect");
                gameVariables.IncorrectPan();
            }
            else
            {
                ovenLight.SetTrigger("correct");
                gameVariables.IncreaseScore(5);
            }
        }

        if (panObject.tag == "Copper")
        {
            if (batter.localScale.y != 0.9f)
            {
                ovenLight.SetTrigger("incorrect");
                gameVariables.IncorrectPan();
            }
            else
            {
                ovenLight.SetTrigger("correct");
                gameVariables.IncreaseScore(10);
            }
        }

        Destroy(panObject);


    }
}
