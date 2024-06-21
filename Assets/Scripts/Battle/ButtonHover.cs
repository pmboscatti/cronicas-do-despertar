using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverTMP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;

    private TextMeshProUGUI buttonText;

    void Start()
    {
        // Obtém a referência ao componente TextMeshProUGUI do botão
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        if (buttonText == null)
        {
            Debug.LogError("Não foi possível encontrar o componente TextMeshProUGUI no botão.");
        }
    }

    // Método chamado quando o mouse entra no botão
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = hoverColor;
        }
    }

    // Método chamado quando o mouse sai do botão
    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = normalColor;
        }
    }
}
