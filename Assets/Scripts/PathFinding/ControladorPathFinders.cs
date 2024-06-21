using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPathFinders : MonoBehaviour
{
    Queue<PedidoDeCaminho> filaPedidos = new Queue<PedidoDeCaminho>();
    PedidoDeCaminho pedidoAtual;

    static ControladorPathFinders instance;
    BuscaAStar pathfinding;

    bool processandoCaminho;


    private void Awake()
    {
        instance = this;
        pathfinding = GetComponent<BuscaAStar>();
    }

    public static void IniciarCaminho(Vector3 inicio, Vector3 fim, Action<Vector3[], bool> callback)
    {
        PedidoDeCaminho novoPedido = new PedidoDeCaminho(inicio, fim, callback);
        instance.filaPedidos.Enqueue(novoPedido);
        instance.TryProcessNext();
    }

    void TryProcessNext()
    {
        if(!processandoCaminho && filaPedidos.Count > 0)
        {
            pedidoAtual = filaPedidos.Dequeue();
            processandoCaminho = true;
            // pathfinding.Busca(pedidoAtual.inicioCaminho);
            pathfinding.IniciarCaminho(pedidoAtual.inicioCaminho, pedidoAtual.fimCaminho);
        }
    }

    public void FimProcessamentoCaminho(Vector3[] caminho, bool sucesso)
    {
        pedidoAtual.callback(caminho, sucesso);
        processandoCaminho = false;
        TryProcessNext();
    }

    struct PedidoDeCaminho
    {
        public Vector3 inicioCaminho;
        public Vector3 fimCaminho;
        public Action<Vector3[], bool> callback;

        public PedidoDeCaminho(Vector3 inicio, Vector3 fim, Action<Vector3[], bool> _callback)
        {
            inicioCaminho = inicio;
            fimCaminho = fim;   
            callback = _callback;
        }
    }
}
