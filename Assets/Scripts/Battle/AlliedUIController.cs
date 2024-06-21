using Assets.Scripts.States;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlliedUIController : MonoBehaviour
{ 
    public void updateEverything(BattleStateMachine fsm)
    {
        var textos = gameObject.GetComponents<TextMeshProUGUI>();



        foreach (Transform i in gameObject.transform)
        {
            var u = i.gameObject.GetComponent<TextMeshProUGUI>();
            print($"current name: {i.gameObject.name}");
            switch (i.gameObject.name)
            {
                case "PlayerName-01":
                    u.text = fsm.aliados[0].nome;
                    break;
                case "HP-Value-01":
                    u.text = $"{fsm.aliados[0].hpAtual}";
                    break;
                case "MP-Value-01":
                    u.text = $"{fsm.aliados[0].hp}";
                    break;
                case "PlayerName-02":
                    u.text = $"{fsm.aliados[1].nome}";
                    break;
                case "HP-Value-02":
                    u.text = $"{fsm.aliados[1].hpAtual}";
                    break;
                case "MP-Value-02":
                    u.text = $"{fsm.aliados[1].hp}";
                    break;
                default:
                    break;
            }

        }
    }
}
