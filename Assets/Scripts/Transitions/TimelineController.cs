using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline;

    void Start()
    {
        // Chamar a fun��o quando a custcene acabar
        timeline.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        // Carregar a pr�xima cena quando a timeline terminar
        SceneManager.LoadScene("Level01");
    }
}
