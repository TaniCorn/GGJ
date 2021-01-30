using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector2 movement;
    [SerializeField] private const float moveSpeed = 8f;
    [SerializeField] private Vector2 gridSize;

    private bool isMoving;
    public Vector2 moveStart;
    public Vector2 moveEnd;
    public float moveTimer;
    public float moveWait;



    //Initialise variables
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        moveWait = 4f;
    }

    //Get Controls
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if ((movement.x != 0 || movement.y != 0) && isMoving == false)//Determines if player is allowed to move(not currently moving and 'movement' has input
        {
            moveTimer = 0;
            moveStart = rb.position;
            moveEnd = rb.position + (movement * gridSize);
            isMoving = true;
        }
        if (moveTimer > moveWait)//determines how long until player can move again
        {
            isMoving = false;
        }

    }

    //Move Player
    private void FixedUpdate()
    {



        if (isMoving == true)
        {
            moveTimer += Time.deltaTime * moveSpeed;//determines how long until player can move again
            rb.MovePosition(new Vector2(Mathf.Lerp(moveStart.x, moveEnd.x, Mathf.Clamp(moveTimer, 0, 1)), Mathf.Lerp(moveStart.y, moveEnd.y, Mathf.Clamp(moveTimer, 0, 1))));//Moves according to gridSize
        }
    }
}
