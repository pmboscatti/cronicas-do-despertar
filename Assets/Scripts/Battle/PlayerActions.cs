using UnityEngine;
using UnityEngine.UI;
using TMPro; // Adicione esta linha para usar TextMesh Pro

public class PlayerActions : MonoBehaviour
{
    public Button attackButton;
    public Button defenseButton;
    public TMP_Text actionStateTMPText; // Componente TMP_Text da UI para mostrar o estado da a��o
    private string actionState; // Vari�vel privada que ser� atualizada

    void Start()
    {
        // Adiciona listeners aos bot�es
        attackButton.onClick.AddListener(OnAttackButtonClick);
        defenseButton.onClick.AddListener(OnDefenseButtonClick);
    }

    void OnAttackButtonClick()
    {
        actionState = "Attack";
        UpdateActionStateText();
    }

    void OnDefenseButtonClick()
    {
        actionState = "Defense";
        UpdateActionStateText();
    }

    void UpdateActionStateText()
    {
        actionStateTMPText.text = "Action State: " + actionState;
    }
}
