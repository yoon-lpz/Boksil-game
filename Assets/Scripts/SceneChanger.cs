using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ChangeScene(nextScene);
    }

    public static void ChangeScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public static void ReloadScene()
    {
        Scene actualScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(actualScene.name);
    }
}
