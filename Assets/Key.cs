using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Door;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Human")
        {

        }
        else if (collision.tag == "Cat")
        {

        }
    }

    void Pickup()
    {

    }

    void KeyIn()
    {

    }
}
