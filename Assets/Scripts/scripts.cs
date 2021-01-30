using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripts : MonoBehaviour
{

    public Rigidbody2D rb;

    public Vector2 movement;
    public float moveSpeed;
    public bool isMoving;
    public Vector2 moveStart;
    public Vector2 moveEnd;
    public float moveTimer;
    public float moveWait;
    public Vector2 gridSize;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 8;
        moveWait = 1.45f;
        gridSize = new Vector2(0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

	    if ((movement.x != 0 || movement.y != 0) && isMoving == false)
        {
            moveTimer = 0;
            moveStart = rb.position;
            moveEnd = rb.position + (movement * gridSize);
            isMoving = true;
        }
        if (moveTimer > moveWait)
        {
            isMoving = false;
        }
 
    }

    private void FixedUpdate()
    {
        if (isMoving == true)
        {
            moveTimer += Time.deltaTime * moveSpeed;
            rb.MovePosition(new Vector2(Mathf.Lerp(moveStart.x, moveEnd.x, Mathf.Clamp(moveTimer,0,1)), Mathf.Lerp(moveStart.y, moveEnd.y, Mathf.Clamp(moveTimer,0,1))));
        }
    }
}
