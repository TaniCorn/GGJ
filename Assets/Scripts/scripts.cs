using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripts : MonoBehaviour
{

    public Rigidbody2D rb;

    public Vector2 movement;
    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            movement = new Vector2(1, 0);
        }
        else
        {
            movement = new Vector2 (0,0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * Time.deltaTime * movementSpeed;
    }
}
