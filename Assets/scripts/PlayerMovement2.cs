using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;
    private bool isGrounded;
    private Animator anim;
    public AudioSource jump;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            moveX = 1f;

        float horizontalInput = moveX;
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(5, 5, 5);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-5, 5, 5);

        body.velocity = new Vector2(moveX * speed, body.velocity.y);
        anim.SetBool("run", moveX != 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
            jump.Play();
    }

    public bool canAttack()
    {
        return isGrounded;  // Attack only while on the ground
    }
}
