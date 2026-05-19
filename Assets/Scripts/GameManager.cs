using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int Lives { get; set; } = 3;

    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI tutorialText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}