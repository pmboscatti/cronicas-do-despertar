using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCollisionHandler : MonoBehaviour
{
    public string sceneToLoad; // Nome da cena para carregar quando ocorrer a colisão

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se bateu na tag do jogador
        if (other.CompareTag("Player"))
        {
            // Carrega a cena
            SceneManager.LoadScene(sceneToLoad);
        }

        Debug.Log(other.tag);
    }
}