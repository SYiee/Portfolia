using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    VideoPlayer vp;
    void Start()
    {
        onplayVideo();


    }

    public void onplayVideo()
    {
        vp = GetComponent<VideoPlayer>();
        vp.url = System.IO.Path.Combine(Application.streamingAssetsPath, "ZeroDream.mp4");
        vp.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
