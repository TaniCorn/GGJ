using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Components")]
    private Rigidbody2D rb;
    public GameObject targetPlayer;
    [Space]

    [Header("Layer Masks")]
    public LayerMask unmovable;
    public LayerMask door;
    [Space]

    [Header("Direction Checks")]
    private RaycastHit2D targetDirection;
    [Space]

    [Header("Movement variables")]
    [SerializeField] private Vector2 movement;
    [SerializeField] [Tooltip("How fast the character moving plays")] private const float moveSpeed = 8.5f;
    [SerializeField] [Tooltip("How much the character will move in worldspace")] private Vector2 moveGridSpace;
    private bool isMoving;
    private Vector2 startMovePosition;
    private Vector2 targetMovePosition;
    [SerializeField] private float moveTimer;
    private float moveWait = 3f;
    #endregion

    //Initialise variables
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    //Get Controls
    void Update()
    {

        #region Unit Movement
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            movement = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            movement = new Vector2(0, 0);
        }
        #endregion


        #region PlayerMoving Control
        if ((movement.x != 0 || movement.y != 0) && isMoving == false)//Determines if player is allowed to move(not currently moving and 'movement' has input
        {
        startMovePosition = rb.position;
        targetMovePosition = rb.position + (movement * moveGridSpace);
        moveTimer = 0;

            if (!Physics2D.Raycast(startMovePosition, movement, moveGridSpace.x, unmovable))
            {
                isMoving = true;
            }
            else if (!Physics2D.Raycast(startMovePosition, movement, 1, unmovable))//Used if cat cannot go forward two but can one
            {
                targetMovePosition = rb.position + (movement);
                isMoving = true;
            }
            else
            {
                Debug.Log("Can't Move");
            }
            //This is very bad code however it'll do for now. Will check if we have key and if so will open door
            targetDirection = Physics2D.Raycast(startMovePosition, movement, 1, door);
            if (targetDirection)
            {
                GetComponent<Inventory>().OpenDoor(targetDirection);
            }
        }
  

        if (moveTimer > moveWait)//determines how long until player can move again
        {

            isMoving = false;
        }
        #endregion

        //Used to allow cat to jump over holes
        if (moveTimer <= 1)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    //Move Player
    private void FixedUpdate()
    {
        if (this.gameObject.tag == "Human")
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Cat");       
        }
        else if (this.gameObject.tag == "Cat") 
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Human");
        }

        Debug.Log(Vector3.Distance(this.gameObject.transform.position, targetPlayer.gameObject.transform.position));
        if (Vector3.Distance(this.gameObject.transform.position, targetPlayer.gameObject.transform.position) < 0.5)
        {

            FindObjectOfType<InGame>().PlayerWin();
        }


        if (isMoving == true)
        {
            moveTimer += Time.deltaTime * moveSpeed;//determines how long until player can move again
            rb.MovePosition(new Vector2(Mathf.Lerp(startMovePosition.x, targetMovePosition.x, Mathf.Clamp(moveTimer, 0, 1)), Mathf.Lerp(startMovePosition.y, targetMovePosition.y, Mathf.Clamp(moveTimer, 0, 1))));//Moves according to gridSize
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Holes")
        {
            //play falling animation? spinning and getting smaller
            FindObjectOfType<InGame>().PlayerDied();
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(moveStart, moveEnd);
        Gizmos.DrawRay(startMovePosition, movement * moveGridSpace);
    }
}
