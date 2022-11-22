using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Threading.Tasks;
using UnityEngine.Networking;



public class InputField_Url : MonoBehaviour
{
    //�����
    public GameObject btn;
    public GameObject inputurl;
    public InputField Field;   

    //�̹�����
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

    // ���� OK��ư
    public void StoreName()
    {

        url = inputurl.GetComponent<Text>().text;

        if (url != "" && url.Contains("https://www.youtube.com/watch?"))
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

    // �̹��� OK��ư
    public void StoreName_P()
    {
        url = inputurl_P.GetComponent<Text>().text;
        present_screen.GetComponent<YoutubeStreaming>().Update_Img(url);


        //_texture = await GetRemoteTexture(inputurl.GetComponent<Text>().text);
        //_material.mainTexture = _texture;

        Debug.Log(url);
        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;

        gameObject.SetActive(false);
        Field_P.Select();
        Field_P.text = "";
        str = "";
    }


}
