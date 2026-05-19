using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public bool isDead = false;
    public float horizontalMovement, force = 7, speed = 3;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isDead)
        {
            if (speed < 0) transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            else transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }

        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }

    public void InvertWalking()
    {
        if (!isDead) speed *= -1;
    }

    public void Die() => Destroy(gameObject);
}
