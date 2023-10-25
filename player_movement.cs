using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_movement : MonoBehaviour
{
    //calling the foodSpawner script to here
   // public logicscript foodSpawner;


    public Rigidbody2D rb;
    public float moveSpeed = 4;
    Vector2 movement;
    bool playerIsAlive;
    //for growth 

    public Transform tail;
    private List<Transform> segments = new List<Transform>();


    public LogicManage logic;
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManage>();
        playerIsAlive = true;

       // segments = new List<Transform>();
        segments.Add(transform);

    }
    // Update is called once per frame
    void Update()
    {
        if (playerIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.W) && movement.y != -1)
            {
                movement.y = 1;
                movement.x = 0;
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
            if (Input.GetKeyDown(KeyCode.S) && movement.y != 1)
            {
                movement.y = -1;
                movement.x = 0;
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
            if (Input.GetKeyDown(KeyCode.D) && movement.x != -1)
            {
                movement.x = 1;
                movement.y = 0;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A) && movement.x != 1)
            {
                movement.x = -1;
                movement.y = 0;
                transform.eulerAngles = new Vector3(180, 0, 180);
            }
        }
    }

    private void FixedUpdate()
    {
        //growth of tail
        if (playerIsAlive) 
            {
                for (int i = segments.Count - 1; i > 0; i--)
                {
                    segments[i].position = segments[i - 1].position;
                }
            }

        //transform.position = new Vector2()
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    public void grow()
    {   
        Transform segment1 = Instantiate(tail);
        segment1.position = segments[segments.Count - 1].position;
        segments.Add(segment1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacles") { 
        logic.gameOverScreen();
        moveSpeed = 0;
        playerIsAlive = false; }
    }


}
