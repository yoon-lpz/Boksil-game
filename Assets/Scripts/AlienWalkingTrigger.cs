using UnityEngine;

public class AlienWalkingTrigger : MonoBehaviour
{
    private EnemyManager enemy;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Map") || (collision.transform.parent != null && collision.transform.parent.CompareTag("Map")))
        {
            enemy.InvertWalking();
        }
    }
}
