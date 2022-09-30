using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Trailer : MonoBehaviour
{
    VideoPlayer vp;
    void Start()
    {
        onplayVideo();
    }

    public void onplayVideo()
    {
        vp = GetComponent<VideoPlayer>();
        vp.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Trailer.mp4");
        vp.Play();
    }
}
