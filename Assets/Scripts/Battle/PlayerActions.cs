using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Assets.Scripts.Model;

public class ButtonHoverTMP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
<<<<<<< HEAD
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
=======
    public Color corNormal = Color.white;
    public Color corHover = Color.yellow;
    public TextMeshProUGUI botaoTexto;

    private string selectedAttack;
    private GameObject selectedEnemy;

    [Header("UI Elements")]
    public GameObject attackListContainer;
    public GameObject enemyListContainer;
    public Button buttonPrefab;

    void Start()
    {
        // Obtém a referência ao componente TextMeshProUGUI do botão
        botaoTexto = GetComponentInChildren<TextMeshProUGUI>();

        if (botaoTexto == null)
        {
            Debug.LogError("Não foi possível encontrar o componente TextMeshProUGUI no botão.");
        }

        // Hide enemy list container at the start
        enemyListContainer.SetActive(false);
>>>>>>> cdbc5c58b52a276af9086e5fadb101b85b61eba3
    }

    // Método chamado quando o mouse entra no botão
    public void OnPointerEnter(PointerEventData eventData)
    {
<<<<<<< HEAD
        actionState = "Attack";
        UpdateActionStateText();
        audioAttack.Play();
=======
        if (botaoTexto != null)
        {
            botaoTexto.color = corHover;
        }
>>>>>>> cdbc5c58b52a276af9086e5fadb101b85b61eba3
    }

    // Método chamado quando o mouse sai do botão
    public void OnPointerExit(PointerEventData eventData)
    {
<<<<<<< HEAD
        actionState = "Defense";
        UpdateActionStateText();
        audioHeal.Play();
    }

    void OnHealButtonClick()
    {
        actionState = "Heal";
        UpdateActionStateText();
        audioHeal.Play();
=======
        if (botaoTexto != null)
        {
            botaoTexto.color = corNormal;
        }
>>>>>>> cdbc5c58b52a276af9086e5fadb101b85b61eba3
    }

    // Método para exibir a lista de ataques
    public void DisplayAttackList(string[] attacks)
    {
        attackListContainer.SetActive(true);
        enemyListContainer.SetActive(false);

        // Clear existing buttons
        foreach (Transform child in attackListContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Create buttons for each attack
        foreach (var attack in attacks)
        {
            var button = Instantiate(buttonPrefab, attackListContainer.transform);
            var text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.text = attack;

            button.onClick.AddListener(() => SelectAttack(attack));
        }
    }

    // Método chamado ao clicar em um ataque
    private void SelectAttack(string attack)
    {
        selectedAttack = attack;
        Debug.Log("Ataque selecionado: " + selectedAttack);

        // Hide attack list and show enemy list
        attackListContainer.SetActive(false);
        enemyListContainer.SetActive(true);
    }

    // Método para exibir a lista de inimigos
    public void DisplayEnemyList(List<GameObject> enemies)
    {
        enemyListContainer.SetActive(true);
        attackListContainer.SetActive(false);

        // Clear existing buttons
        foreach (Transform child in enemyListContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Create buttons for each enemy
        foreach (var enemy in enemies)
        {
            var button = Instantiate(buttonPrefab, enemyListContainer.transform);
            var text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.text = enemy.name;

            button.onClick.AddListener(() => SelectEnemy(enemy));
        }
    }

    // Método chamado ao clicar em um inimigo
    private void SelectEnemy(GameObject enemy)
    {
        selectedEnemy = enemy;
        Debug.Log("Inimigo selecionado: " + selectedEnemy.name);

        // Optionally, hide the enemy list after selection
        enemyListContainer.SetActive(false);
    }
}
