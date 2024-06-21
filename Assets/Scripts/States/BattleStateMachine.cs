

using Assets.Scripts.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class BattleStateMachine : MonoBehaviour
    {
        BattleStates atual;
       
        public BattleStateEnd battleStateEnd = new BattleStateEnd();
        public BattleStateChoice battleStateChoice = new BattleStateChoice();
        public BattleStateExecute battleStateExecute = new BattleStateExecute();
        public List<Personagem> aliados;
        public List<Inimigo> inimigos;

        public AlliedUIController controlador;



        public MaxHeap acoesRodada;

        void Awake()
        {
            aliados = new();
            inimigos = new();
            UnityEngine.Object[] jogaveis = FindObjectsOfType(typeof(Personagem));

            Personagem[] personagens = new Personagem[jogaveis.Length];
            print(jogaveis.Length);

            for(int i = 0; i < jogaveis.Length; i++)
            {
                personagens[i] = jogaveis[i].GetComponent<Personagem>();
                print(personagens[i].nome);
            }

            foreach (Personagem p in personagens)
            {
                if (p.GetType() == typeof(Inimigo))
                {
                    Inimigo inimigoAtual = (Inimigo)p;
                    Ataque[] ataques = new Ataque[2];
                    Magia[] magias = new Magia[2];
                    ataques[0] = new Ataque("ataque de espada", 8, 90, 50);
                    ataques[1] = new Ataque("ataque de espada forte", 8, 80, 70);
                    magias[0] = new Magia("Lança chamas", 8, 90, 50);
                    magias[1] = new Magia("Bola de fogo", 8, 80, 70);
                    inimigoAtual.ataques = ataques;
                    inimigoAtual.magias = magias;


                    inimigos.Add(inimigoAtual);

                }
                else 
                {
                    Ataque[] ataques = new Ataque[2];
                    Magia[] magias = new Magia[2];
                    Cura[] curas = new Cura[2];
                    ataques[0] = new Ataque("ataque de espada", 8, 90, 50);
                    ataques[1] = new Ataque("ataque de machado", 8, 80, 70);
                    magias[0] = new Magia("Lança chamas", 8, 90, 50);
                    magias[1] = new Magia("Bola de fogo", 8, 80, 70);
                    curas[0] = new Cura("Recuperar", 5, 90, 50);
                    curas[1] = new Cura("Benção do Deus do Sol ", 5, 70, 100);
                    if(p.nome == "Guerreiro")
                    {
                        p.ataques = ataques;
                        p.magias = magias;

                    }
                    Status[] status = new Status[6];
                    status[0] = new Status("Maldição de lentidão", 5, 70, Stat.velocidade, -2);
                    status[1] = new Status("Intimidar", 5, 90, Stat.atk, -1);
                    status[2] = new Status("Benção de força", 5, 90, Stat.atk, 1);
                    status[3] = new Status("Pele de pedra", 5, 90, Stat.def, 1);
                    status[4] = new Status("Benção de Hermes", 5, 90, Stat.velocidade, 1);
                    status[5] = new Status("Armadura mágica", 5, 90, Stat.spdef, 1);
                    if(p.nome == "Mago")
                    {
                        p.ataques = ataques;
                        p.magias = magias;
                        p.status = status;
                    }
                    aliados.Add(p);
                    print($"ADICIONADO A ALIADOS: {p.nome} ");
                }

            }
            Debug.Log("Iniciando estados");
            atual = battleStateEnd;
            atual.Start(this);
        }

        void Update()
        {
            atual.Work(this);   
        }

        public void TrocaEstado(BattleStates novoEstado)
        {
            controlador.updateEverything(this);
            atual.End(this);
            atual = novoEstado;
            atual.Start(this);
        }

        
    }

}