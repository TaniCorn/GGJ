using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = target.transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Human")
        {
            target = collision.gameObject;
            Debug.Log("human");
        }
        else if (collision.tag == "Cat")
        {
            target = collision.gameObject;
            Debug.Log("Cat");
        }

        if(collision.tag == "Door")
        {
            Debug.Log("Des");
            KeyIn();
        }
    }

    void KeyIn()
    {
        Destroy(door.gameObject);
        Destroy(this.gameObject);

    }
}
