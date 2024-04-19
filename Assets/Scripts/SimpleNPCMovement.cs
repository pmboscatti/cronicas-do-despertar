using UnityEngine;

public class SimpleNPCMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidade de movimento do NPC
    public Transform[] waypoints; // Pontos ao longo dos quais o NPC irá se mover
    private int currentWaypointIndex = 0; // Índice do ponto atual

    Rigidbody2D rbody;
    IsometricCharacterRenderer isoRenderer;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void Update()
    {
        // Verifica se há pontos para percorrer
        if (waypoints.Length > 0)
        {
            // Calcula a direção para o próximo ponto
            Vector2 direction = ((Vector2)waypoints[currentWaypointIndex].position - (Vector2)transform.position).normalized;

            // Move o NPC na direção do próximo ponto
            Vector2 movement = direction * speed;
            isoRenderer.SetDirection(movement);
            transform.Translate(direction * speed * Time.deltaTime);

            // Verifica se o NPC chegou ao ponto atual
            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                // Se sim, avança para o próximo ponto
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}