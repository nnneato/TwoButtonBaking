using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePan : MonoBehaviour
{

    public Rigidbody panRB;
    private GameObject logicStuff;
    private GameVariables gameVariables;
    private Transform[] childTransforms;
    private Transform batter;
    private int speed;
    private string color;


    private void Start()
    {
        childTransforms = this.GetComponentsInChildren<Transform>();
        batter = childTransforms[1];
        logicStuff = GameObject.FindWithTag("Logic");
        gameVariables = logicStuff.GetComponent<GameVariables>();

        if (gameObject.tag == "Copper")
        {
            color = "Copper";
        }

        if (gameObject.tag == "Silver")
        {
            color = "Silver";
        }
    }

    private void Update()
    {
        speed = gameVariables.beltSpeed;
        panRB.velocity = new Vector3(speed, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Batter")
        {
            AddBatter();
            gameVariables.DestroyObj(collision.gameObject);
        }
    }

    void AddBatter()
    {
        float batterSize = batter.localScale.y;
        if (color == "Silver")
        {
        gameVariables.BatterHit();
            batterSize += 0.2f;
            batter.localScale = new Vector3(1, batterSize, 1);
        }

        if (color == "Copper")
        {
        gameVariables.BatterHit();
            batterSize += .90f;
            batter.localScale = new Vector3(1, batterSize, 1);
        }
    }
}
