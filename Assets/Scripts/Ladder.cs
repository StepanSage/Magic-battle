using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [Header("ClimbUpToLadder")]
    private float SpeedLadder=10f;
    private Rigidbody2D rb;

    void Start()
    {
       rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (collision.gameObject.tag == "Player")
        {   
            if (Input.GetKey(KeyCode.W))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, SpeedLadder);
            }else if (Input.GetKey(KeyCode.S))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -SpeedLadder);
            }else
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().gravityScale= 1;
        }
    }
}
