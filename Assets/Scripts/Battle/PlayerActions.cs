using UnityEngine;
using UnityEngine.UI;
using TMPro; // Adicione esta linha para usar TextMesh Pro

public class PlayerActions : MonoBehaviour
{
    public Button attackButton;
    public Button defenseButton;
    public TMP_Text actionStateTMPText; // Componente TMP_Text da UI para mostrar o estado da ação
    private string actionState; // Variável privada que será atualizada

    void Start()
    {
        // Adiciona listeners aos botões
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
