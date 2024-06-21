using UnityEngine;
using UnityEngine.UI;
using TMPro; // Adicione esta linha para usar TextMesh Pro

public class PlayerActions : MonoBehaviour
{
    public Button attackButton;
    public AudioSource audioAttack;

    public Button defenseButton;
    public AudioSource audioDefense;

    public Button healButton;
    public AudioSource audioHeal;

    public TMP_Text actionStateTMPText; // Componente TMP_Text da UI para mostrar o estado da a��o
    private string actionState; // Vari�vel privada que ser� atualizada

    void Start()
    {
        // Adiciona listeners aos bot�es
        attackButton.onClick.AddListener(OnAttackButtonClick);
        defenseButton.onClick.AddListener(OnDefenseButtonClick);
        healButton.onClick.AddListener(OnHealButtonClick);
    }

    void OnAttackButtonClick()
    {
        actionState = "Attack";
        UpdateActionStateText();
        audioAttack.Play();
    }

    void OnDefenseButtonClick()
    {
        actionState = "Defense";
        UpdateActionStateText();
        audioHeal.Play();
    }

    void OnHealButtonClick()
    {
        actionState = "Heal";
        UpdateActionStateText();
        audioHeal.Play();
    }

    void UpdateActionStateText()
    {
        actionStateTMPText.text = "Action State: " + actionState;
    }
}
