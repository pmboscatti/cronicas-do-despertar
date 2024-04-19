using UnityEngine;

public class SimpleNPCMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidade de movimento do NPC
    public Transform[] waypoints; // Pontos ao longo dos quais o NPC ir� se mover
    private int currentWaypointIndex = 0; // �ndice do ponto atual
    IsometricCharacterRenderer isoRenderer;

    void Update()
    {
        // Verifica se h� pontos para percorrer
        if (waypoints.Length > 0)
        {
            // Calcula a dire��o para o pr�ximo ponto
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.Normalize();

            // Move o NPC na dire��o do pr�ximo ponto
            transform.Translate(direction * speed * Time.deltaTime);


            // Verifica se o NPC chegou ao ponto atual
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                // Se sim, avan�a para o pr�ximo ponto
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}
