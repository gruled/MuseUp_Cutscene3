using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private PlayableDirector playableDirector;
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        playableDirector = GetComponent<PlayableDirector>();
        StartCoroutine(Upd());
    }

    private IEnumerator Upd()
    {
        while (true)
        {
            if (meshRenderer.enabled&&playableDirector.state==PlayState.Paused)
            {
                playableDirector.Play();
            }

            if (!meshRenderer.enabled&&playableDirector.state==PlayState.Playing)
            {
                playableDirector.Pause();
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
}
