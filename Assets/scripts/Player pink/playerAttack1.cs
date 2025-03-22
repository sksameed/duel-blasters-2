using System.Collections;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer1 = Mathf.Infinity;
    private int fireballIndex = 0;  // Track which fireball to use next

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K) && cooldownTimer1 > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        cooldownTimer1 += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer1 = 0;

        // Use the next fireball in the array (cycling back to 0)
        GameObject fireball = fireballs[fireballIndex];
        fireballIndex = (fireballIndex + 1) % fireballs.Length;

        fireball.transform.position = firePoint.position;
        fireball.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
