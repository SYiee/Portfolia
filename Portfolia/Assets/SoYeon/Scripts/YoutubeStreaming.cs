using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class YoutubeStreaming : MonoBehaviour
{
    public string url;
    public GameObject inputurl;
    public GameObject inputField;
    public InputField Field;
    public GameObject btn;
    private string str = "";


    VideoPlayer vp;


    public void StoreName()
    {
       
        url = inputurl.GetComponent<Text>().text;

        if(url != "")
        {
            vp = GetComponent<VideoPlayer>();

            for (int i = 0; i <= url.Length; i++)
            {
                if (url[i] == '=')
                {
                    for (int j = i + 1; j < url.Length; j++)
                    {
                        str += url[j];
                    }
                    break;
                }
            }

            vp.url = "https://unity-youtube-dl-server.herokuapp.com/watch?v=" + str + "&cli=yt-dlp";
            vp.Play();
        }
        

        //inputurl.GetComponent<Text>().text = "";
        btn.SetActive(false);
        inputField.SetActive(false);
        Field.Select();
        Field.text = "";
    }


    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    bool isDoubleClicked = false;

    private void OnMouseUp()
    {
        if ((Time.time - doubleClickedTime) < interval)
        {
            isDoubleClicked = true;
            doubleClickedTime = -1.0f;
        }
        else
        {
            isDoubleClicked = false;
            doubleClickedTime = Time.time;
        }
    }

    void Update()
    {
        if (isDoubleClicked)
        {
            btn.SetActive(true);
            inputField.SetActive(true);
            isDoubleClicked = false;
        }
    }




}
