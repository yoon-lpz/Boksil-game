using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
    public TextMeshProUGUI livesText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateLives();
    }

    public void UpdateLives()
    {
        livesText.text = $"X{GameManager.Lives}";
    }
}
