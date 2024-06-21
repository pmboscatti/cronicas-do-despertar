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
        // Obt�m a refer�ncia ao componente TextMeshProUGUI do bot�o
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

        if (buttonText == null)
        {
            Debug.LogError("N�o foi poss�vel encontrar o componente TextMeshProUGUI no bot�o.");
        }
    }

    // M�todo chamado quando o mouse entra no bot�o
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = hoverColor;
        }
    }

    // M�todo chamado quando o mouse sai do bot�o
    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = normalColor;
        }
    }
}
