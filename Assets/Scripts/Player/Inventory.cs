using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameObject pickedUpObject;//Stored Object
    [SerializeField] private LayerMask noDropzone;

    public void Update()
    {
        pickedUpObject.transform.position = this.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))//Drop Item
        {
            DropItem();
        }
    }

    /// <summary>
    /// Will Raycast in 4 unit directions around the gameobject and will drop 'pickedUpObject' onto emptyGround
    /// </summary>
    void DropItem()
    {
        Vector2 originalPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        Vector2[] direction = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0,-1) };//Unit vectors for all 4 directions

        //We could potentially change this so that the player will drop keys based on what direction they went last or using arrow keys, room for thought in the future
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 0; i < 4; i++)//Checks all 4 directions, if one is empty. Drop object once
        {
            if (!Physics2D.Raycast(originalPosition, direction[i], 1, noDropzone))
            {
                FindObjectOfType<AudioManager>().PlaySound("DropKey");
                pickedUpObject.GetComponent<BoxCollider2D>().enabled = true;
                Instantiate(pickedUpObject, originalPosition + direction[i], transform.rotation);
                Destroy(pickedUpObject);
                break;
            }
        }
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    //When walking onto object with 'Key' Tag, pick it up. Cannot pick up two keys at the same time
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Key" && pickedUpObject == null)
        {
            FindObjectOfType<AudioManager>().PlaySound("PickupKey");
            pickedUpObject = collision.gameObject;
            pickedUpObject.GetComponent<BoxCollider2D>().enabled = false;//turns off collider so we can drop it later
        }

    }

    /// <summary>
    /// If we have key and there is a door in the direction we want to move in. Destroy both objects
    /// </summary>
    /// <param name="doorRay"></param>
    public void OpenDoor(RaycastHit2D doorRay)
    {
        if (pickedUpObject.gameObject.tag == "Key")
        {
            if(doorRay.collider.gameObject.tag == "Door")
            {
                Destroy(pickedUpObject);
                Destroy(doorRay.collider.gameObject);
            }
        }
    }

}
