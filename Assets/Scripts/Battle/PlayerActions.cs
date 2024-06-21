using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Assets.Scripts.Model;

public class ButtonHoverTMP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
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
    }

    // Método chamado quando o mouse entra no botão
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (botaoTexto != null)
        {
            botaoTexto.color = corHover;
        }
    }

    // Método chamado quando o mouse sai do botão
    public void OnPointerExit(PointerEventData eventData)
    {
        if (botaoTexto != null)
        {
            botaoTexto.color = corNormal;
        }
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
