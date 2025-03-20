using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 10f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private Animator anim;
    public GameObject snowBall;
    public Transform throwPoint;
    public KeyCode throwBall;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        //flip
        if (horizontalInput > 0.01f)
            transform.localScale =  new Vector3(5,5,5);
        else if (horizontalInput < -0.01f)
             transform.localScale = new Vector3(-5, 5, 5);
        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            isGrounded = false;
        }
        anim.SetBool("run",horizontalInput != 0);

        //throwing
        if (Input.GetKeyDown(throwBall)){
            Instantiate(snowBall,throwPoint.position,throwPoint.rotation);
            anim.SetTrigger("throw");
        }
        
    }
    //set animation
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
