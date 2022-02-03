using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLinePlayerIntro : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayableDirector director;
    public GameObject AnimationDirector;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        AnimationDirector.SetActive(true);
    }

    private void Director_Played(PlayableDirector obj)
    {
        AnimationDirector.SetActive(false);
    }

    private void Start()
    {
        StartTimeline();
    }
    public void StartTimeline()
    {
        director.Play();
    }
}