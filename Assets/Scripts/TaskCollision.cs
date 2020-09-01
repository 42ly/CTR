using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<MenuLogic>().loadRandomTask();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<MenuLogic>().loadRandomTask();
        }
    }
}
