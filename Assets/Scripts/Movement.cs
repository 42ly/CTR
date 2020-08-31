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
    private Animator demonAnimator;
    public bool canMove;
    private void Start()
    {
        canMove = false;
        player = GameObject.Find("GameManager").GetComponent<LevelData>().playerInstance;
        if (this.gameObject == player)
        {
            playerAnimator = GetComponent<Animator>();
            speed = 7;
        }
        else
        {
            speed = 4;
            demonAnimator = GetComponent<Animator>();
        }
    }
    private void Update()
    {
        if (this.gameObject == GameObject.Find("GameManager").GetComponent<LevelData>().playerInstance)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (direction.x == 0 && direction.y == 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                playerAnimator.Play("Idle");
            }
            else if (direction.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                playerAnimator.Play("Run");
            }
            else if (direction.x < 0)
            {

                playerAnimator.Play("Run");
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                playerAnimator.Play("Run");
            }
        }
        else if (canMove == true)
        {
            direction = player.transform.position - transform.position;
            if (direction.x == 0 && direction.y == 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                demonAnimator.Play("DemonIdle");
            }
            else if (direction.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                demonAnimator.Play("DemonRun");
            }
            else if (direction.x < 0)
            {

                demonAnimator.Play("DemonRun");
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                demonAnimator.Play("DemonRun");
            }
        }
        else
        {
            direction = new Vector2(0, 0);
        }
        velocity = direction.normalized * speed;
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + velocity * Time.deltaTime);
    }
}
