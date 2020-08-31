using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    private int speed;
    private Vector2 velocity;
    private Vector2 direction, dashDirection3D, dashDirection;
    private GameObject player;
    private Animator playerAnimator;
    private void Start()
    {
        player = GameObject.Find("GameManager").GetComponent<LevelData>().playerInstance;
        if (this.gameObject == player)
        {
            playerAnimator = GetComponent<Animator>();
            speed = 7;
        }
        else
            speed = 4;
    }
    private void Update()
    {
        if (this.gameObject == GameObject.Find("GameManager").GetComponent<LevelData>().playerInstance)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if(direction.x == 0 && direction.y == 0)
            {
                playerAnimator.Play("Idle");
                playerAnimator.SetBool("isRunning", false);
            }
            else
            {
                playerAnimator.SetBool("isRunning", true);
            }
        }
        else
        {
            direction = player.transform.position - transform.position;
        }
        velocity = direction.normalized * speed;
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + velocity * Time.deltaTime);
    }
}
