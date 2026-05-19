using Unity.VisualScripting;
using UnityEngine;
public class JumpController : MonoBehaviour
{
    private PlayerController playerScript;
    private void Start()
    {
        playerScript = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Map")) playerScript.JumpController(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Map")) playerScript.JumpController(false);
    }
}