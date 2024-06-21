using Assets.Scripts.Model;
using Assets.Scripts.States;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Battle
{
    public class EnemyListTracker : MonoBehaviour
    {

        public BattleStateMachine fsm;
        List<GameObject> listaInimigos;

        void Awake()
        {
            listaInimigos = new List<GameObject>();
            foreach(Inimigo enemy in fsm.inimigos)
            {
                print(fsm.inimigos.Count);
                GameObject novoTextoObject = new GameObject(enemy.name);
                TextMeshProUGUI textoAtual = novoTextoObject.AddComponent<TextMeshProUGUI>();
                textoAtual.transform.parent = transform;
                textoAtual.text = $"{enemy.nome} - {enemy.hpAtual}/{enemy.hp}";
                listaInimigos.Add(novoTextoObject);

            }
            
        }

        void Update()
        {
            foreach (Inimigo enemy in fsm.inimigos)
            {
                foreach(GameObject objetoAtual in listaInimigos)
                {
                    TextMeshProUGUI texto = objetoAtual.GetComponent<TextMeshProUGUI>();
                    if(texto.name == enemy.name)
                    {
                        texto.text = $"{enemy.nome} - {enemy.hpAtual}/{enemy.hp}";
                    }
                }

            }
        }
    }

}