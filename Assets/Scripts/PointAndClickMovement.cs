using UnityEngine;

public class PointAndClickMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float arrivalThreshold = 0.1f; // Margem de erro para considerar que o personagem chegou ao destino
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;
    private Vector2 targetPosition; // Posição alvo do clique

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
            // Converte a posição do clique na tela para uma posição no mundo
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    // FixedUpdate é utilizado para movimentações baseadas em física
    void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;
        // Calcula o vetor de movimento em direção à posição alvo
        Vector2 movement = (targetPosition - rbody.position).normalized * movementSpeed;

        // Verifica se o personagem está próximo o suficiente da posição alvo
        if (Vector2.Distance(currentPos, targetPosition) > arrivalThreshold)
        {
            // Define a direção do personagem no IsometricCharacterRenderer
            isoRenderer.SetDirection(movement);
            Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
            // Move o personagem em direção à posição alvo
            rbody.MovePosition(newPos);
        }
        else
        {
            // Se o personagem estiver próximo o suficiente, pare o movimento
            rbody.velocity = Vector2.zero;
            isoRenderer.SetDirection(Vector2.zero);
        }
    }
}
