using TMPro;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    public static EndScreenController Instance { get; private set; }
    public TextMeshProUGUI endText;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        endText.text = GameManager.Lives > 0 ? "You won!" : "GAME OVER";
    }
}
