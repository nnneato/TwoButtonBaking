using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBatter : MonoBehaviour
{

    public Rigidbody batterRB;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        batterRB.velocity = new Vector3(0f, -10f, 0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ConveyorBelt")
        {
            Destroy(gameObject);
        }
    }
}
