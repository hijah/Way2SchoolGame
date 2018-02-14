using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    private bool isobjecthit = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void onTriggerEnter2D(Collider2D other)
    {
        if (isobjecthit == false)
        {
            if (other.tag == "Player")
            {
                isobjecthit = true;
            }
        }

    }
}
