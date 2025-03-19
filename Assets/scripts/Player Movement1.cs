using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;
    private bool isGrounded;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
    
        
        // Horizontal movement using A and D keys only
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A))
            moveX = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveX = 1f;
         float horizontalInput = moveX; // Change horizontalInput to follow moveX
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(5, 5, 5);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-5, 5, 5);
        body.velocity = new Vector2(moveX * speed, body.velocity.y);
        // set animations 
        anim.SetBool("run", moveX != 0);

        // Jumping with ground check (using W key)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}