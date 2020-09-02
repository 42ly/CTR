using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorLogic : MonoBehaviour
{
    public GameObject demonInstance;
    private GameObject playerInstance;

    private void Start()
    {
        playerInstance = GameObject.Find("GameManager").GetComponent<LevelData>().playerInstance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == playerInstance)
        {
            Debug.Log("Collided with" + collision.gameObject.tag);
            demonInstance.GetComponent<Movement>().canMove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == playerInstance)
        {
            demonInstance.GetComponent<Movement>().canMove = false;
        }
    }
    private void Update()
    {
        if (demonInstance)
            transform.position = demonInstance.transform.position;
        else
            Destroy(this.gameObject);
    }
}
