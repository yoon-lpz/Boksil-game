using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI textMeshPro;
    private Material textMaterial;

    [Header("Start button light config")]
    [Range(0f, 1f)] public float normalGlow = 0f;
    [Range(0f, 1f)] public float hoverGlow = 0.6f;
    public float transitionSpeed = 8f;

    private float objectiveGlow;
    private float actualGlow;

    void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        if (textMeshPro != null)
        {
            textMaterial = textMeshPro.fontMaterial;
            objectiveGlow = normalGlow;
            actualGlow = normalGlow;
            textMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, normalGlow);
        }
        else
        {
            Debug.LogError("There's no text in button!");
        }
    }

    void Update()
    {
        actualGlow = Mathf.Lerp(actualGlow, objectiveGlow, Time.deltaTime * transitionSpeed);
        textMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, actualGlow);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        objectiveGlow = hoverGlow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectiveGlow = normalGlow;
    }

    public static void StartGame()
    {
        GameManager.Lives = 3;
        SceneChanger.ChangeScene("Beginning");
    }
}
