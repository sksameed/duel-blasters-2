using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 10f;
    public float jumpForce = 10f;
    private bool isGrounded;
    private Animator anim;
    

    public Transform firePoint; // Position where bullets spawn
    public GameObject bulletPrefab; // Bullet prefab reference
    public float bulletSpeed = 10f;

    public float attackRate = 0.5f;
    private float nextAttackTime = 0f;

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
           if (Time.time >= nextAttackTime && Input.GetKey(KeyCode.Space))
        {
            Shoot();
            nextAttackTime = Time.time + attackRate;
        }
    }
    //set animation
    void Shoot()
    {
        // // Play attack animation
        // anim.SetBool("Attack",);

        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get Rigidbody2D and set velocity based on player's facing direction
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        float direction = transform.localScale.x > 0 ? 1f : -1f; // Check player's facing direction
        bulletRb.velocity = new Vector2(bulletSpeed * direction, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
