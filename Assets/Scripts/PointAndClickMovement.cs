using UnityEngine;

public class PointAndClickMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float arrivalThreshold = 0.1f; // Margem de erro para considerar que o personagem chegou ao destino
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;
    private Vector2 targetPosition; // Posi��o alvo do clique

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void Update()
    {
        // Verifica se houve um clique do mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Converte a posi��o do clique na tela para uma posi��o no mundo
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    // FixedUpdate � utilizado para movimenta��es baseadas em f�sica
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        // Calcula o vetor de movimento em dire��o � posi��o alvo
        Vector2 movement = (targetPosition - rbody.position).normalized * movementSpeed;

        // Verifica se o personagem est� pr�ximo o suficiente da posi��o alvo
        if (Vector2.Distance(currentPos, targetPosition) > arrivalThreshold)
        {
            // Define a dire��o do personagem no IsometricCharacterRenderer
            isoRenderer.SetDirection(movement);
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            // Move o personagem em dire��o � posi��o alvo
            rbody.MovePosition(newPos);
        }
        else
        {
            // Se o personagem estiver pr�ximo o suficiente, pare o movimento
            rbody.velocity = Vector2.zero;
            isoRenderer.SetDirection(Vector2.zero);
        }
    }
}
