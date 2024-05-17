using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{

    public GeradorGrafo grid;
    public Transform Origem;
    public Transform Destino;
    public BuscaAStar busca;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Verifica se o mouse está sobre um elemento de UI para evitar conflitos
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            // Converte a posição do mouse para coordenadas do mundo
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;

            // Define a posição do objeto do mouse para auxiliar na visualização (opcional)
            transform.position = mouseWorldPos;

            // Obtém os vértices de origem e destino com base nas posições definidas
            Vertice origem = grid.GetVerticeFromPosition(Origem.position);
            Vertice destino = grid.GetVerticeFromPosition(Destino.position);

            if (origem != null && destino != null)
            {
                // Realiza a busca A* e obtém o caminho
                List<Vertice> caminho = busca.EncontrarCaminho(origem, destino);
                // Use o caminho retornado conforme necessário
            }
            else
            {
                Debug.Log("Posição de clique inválida.");
            }
        }
    }
}
