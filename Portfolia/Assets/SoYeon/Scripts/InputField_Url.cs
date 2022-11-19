using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Threading.Tasks;
using UnityEngine.Networking;



public class InputField_Url : MonoBehaviour
{
    //영상용
    public GameObject btn;
    public GameObject inputurl;
    public InputField Field;   

    //이미지용
    public GameObject btn_P;
    public GameObject inputurl_P;
    public InputField Field_P;

    public string url;
    private string str = "";

    Shader shader;

    public VideoPlayer vp;
    public Material _material;
    Texture2D _texture;

    public GameObject present_screen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // 영상 OK버튼
    public void StoreName()
    {

        url = inputurl.GetComponent<Text>().text;

        if (url != "")
        {

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

        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        //inputurl.GetComponent<Text>().text = "";
        gameObject.SetActive(false);
        Field.Select();
        Field.text = "";
        str = "";
    }

    // 이미지 OK버튼
    public void StoreName_P()
    {
        url = inputurl_P.GetComponent<Text>().text;
        present_screen.GetComponent<YoutubeStreaming>().Update_Img(url);


        //_texture = await GetRemoteTexture(inputurl.GetComponent<Text>().text);
        //_material.mainTexture = _texture;

        Debug.Log(url);

        gameObject.SetActive(false);
        Field_P.Select();
        Field_P.text = "";
        str = "";
    }


}
