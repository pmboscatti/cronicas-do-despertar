using UnityEngine;

public class SimpleNPCMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidade de movimento do NPC
    public Transform[] waypoints; // Pontos ao longo dos quais o NPC ir� se mover
    private int currentWaypointIndex = 0; // �ndice do ponto atual

    Rigidbody2D rbody;
    IsometricCharacterRenderer isoRenderer;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void Update()
    {
        // Verifica se h� pontos para percorrer
        if (waypoints.Length > 0)
        {
            // Calcula a dire��o para o pr�ximo ponto
            Vector2 direction = ((Vector2)waypoints[currentWaypointIndex].position - (Vector2)transform.position).normalized;

            // Move o NPC na dire��o do pr�ximo ponto
            Vector2 movement = direction * speed;
            isoRenderer.SetDirection(movement);
            transform.Translate(direction * speed * Time.deltaTime);

            // Verifica se o NPC chegou ao ponto atual
            if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                // Se sim, avan�a para o pr�ximo ponto
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}