using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private bool canJump = false;
    private Animator animator;
    private Rigidbody2D rb;
    public float horizontalMovement, force = 7, speed = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("w") && canJump) rb.AddForce(transform.up * force, ForceMode2D.Impulse);

        float treshold = 0.1f;
        animator.SetBool("isRunning", Mathf.Abs(horizontalMovement) > treshold);

        if (horizontalMovement > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalMovement < 0) transform.localScale = new Vector3(-1, 1, 1);

        animator.SetBool("isGrounded", canJump);
    }

    private void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalMovement * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Aliens"))
        {
            bool isStomping = collision.contacts[0].normal.y > 0.5f;

            if (isStomping)
            {
                EnemyManager enemy = collision.gameObject.GetComponent<EnemyManager>();
                if (enemy != null)
                {
                    enemy.Die();
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 8f);
                }
            }
            else
            {
                GameManager.Lives--;

                if (UIController.Instance != null)
                {
                    UIController.Instance.UpdateLives();
                }
                else
                {
                    Debug.LogWarning("Warning: UIController not found.");
                }

                Die();
            }
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            GameManager.Lives--;

            if (UIController.Instance != null)
            {
                UIController.Instance.UpdateLives();
            }
            else
            {
                Debug.LogWarning("Warning: UIController not found.");
            }

            Die();
        }
    }

    public void JumpController(bool jumpChanger) => canJump = jumpChanger;

    public void Die()
    {
        if (GameManager.Lives > 0) SceneChanger.ReloadScene();
        else
        {
            SceneChanger.ChangeScene("EndScreen");
        }
        
    }

}