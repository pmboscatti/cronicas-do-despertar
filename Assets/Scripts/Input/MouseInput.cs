using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            transform.position = mouseWorldPos;
            Vertice alvo = grid.GetVerticeFromPosition(this.transform.position);
            if (alvo != null && alvo.walkable)
                ControladorPathFinders.IniciarCaminho(unidade.transform.position, unidade.alvo.position, unidade.CaminhoEncontrado);
            else
                print("Posição de click invalida.");
        }
    }
}
