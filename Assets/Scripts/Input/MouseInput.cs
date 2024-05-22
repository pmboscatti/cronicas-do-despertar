using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour
{

    public GeradorGrafo grid;
    public Unidade unidade;
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
            Vertice alvo = grid.GetVerticeFromPosition(this.transform.position);
            if (alvo != null && alvo.walkable)
                ControladorPathFinders.IniciarCaminho(unidade.transform.position, unidade.alvo.position, unidade.CaminhoEncontrado);
            else
                print("Posi��o de click invalida.");
        }
    }
}
