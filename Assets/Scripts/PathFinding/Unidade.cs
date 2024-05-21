using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Unidade : MonoBehaviour
{
    public Transform alvo;
    public int velocidade = 10;
    Vector3[] caminho;
    int indiceAtual;
    IsometricCharacterRenderer isoRenderer;
    void Start()
    {
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    public void CaminhoEncontrado(Vector3[] caminho, bool sucesso)
    {
        if (sucesso)
        {
            this.caminho = caminho;
            indiceAtual = 0;
            StopCoroutine("PercorrerCaminho");
            StartCoroutine("PercorrerCaminho");
        }
    }

    IEnumerator PercorrerCaminho()
    {
        Vector3 pontoAtual = caminho[0];
        while(true)
        {
            if(indiceAtual < caminho.Length - 1) isoRenderer.SetDirection(caminho[indiceAtual + 1]);
            if(transform.position == pontoAtual)
            {
                indiceAtual++;
                if(indiceAtual >= caminho.Length)
                {
                    isoRenderer.SetDirection(Vector2.zero);
                    yield break;
                }
                pontoAtual = caminho[indiceAtual];

            }
            isoRenderer.SetDirection(caminho[indiceAtual]);
            transform.position = Vector3.MoveTowards(transform.position, pontoAtual, velocidade * Time.deltaTime);
            yield return null;
        }
;
    }

    public void OnDrawGizmos()
    {
        if(caminho != null)
        {
            for(int i = indiceAtual; i < caminho.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(caminho[i], new Vector3(-0.2f,-0.2f,-0.2f));
                if(i == indiceAtual)
                {
                    Gizmos.DrawLine(transform.position, caminho[i]);
                }
                else
                {
                    Gizmos.DrawLine(caminho[i-1], caminho[i]);
                }
            }
        }
    }
}
