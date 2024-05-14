using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline;

    void Start()
    {
        // Chamar a função quando a custcene acabar
        timeline.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // Carregar a próxima cena quando a timeline terminar
        SceneManager.LoadScene("Level01");
    }
}
