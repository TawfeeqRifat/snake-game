using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    

    public LogicManage logic;

    void Start()    
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManage>();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("food eaten");
         
            logic.eat();

        }
    }
}
