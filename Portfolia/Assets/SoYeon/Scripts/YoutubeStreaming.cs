using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Threading.Tasks;
using UnityEngine.Networking;


public class YoutubeStreaming : MonoBehaviour
{
    // ¿µ»ó¿ë
    public GameObject inputurl;
    public GameObject inputfield;
    public InputField Field;
    public bool is_leftscreen;

    private string str = "";

    public bool already_out = false;

    VideoPlayer v_player;



    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    bool isDoubleClicked = false;

    private void Start()
    {
        v_player = GetComponent<VideoPlayer>();
    }

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
            ThirdPersonOrbitCamBasic.Instance.can_cam_move = false;

            if (!already_out)
                ScreenOut();
            inputfield.SetActive(true);
            inputfield.GetComponent<InputField_Url>().vp = v_player;
            inputfield.GetComponent<InputField_Url>()._material = gameObject.GetComponent<Renderer>().material;
            inputfield.GetComponent<InputField_Url>().present_screen = gameObject;
            isDoubleClicked = false;
        }
    }

    public void Update_Img(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            Debug.Log("REQ error??");
        }
        else
        {

            //Texture2D tex = new Texture2D(2, 2);
            gameObject.GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Texture"));
            gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;

        }
    }

    void ScreenOut()
    {
        if(is_leftscreen)
            gameObject.transform.position += new Vector3(-0.8f, 0, 0);
        else
            gameObject.transform.position += new Vector3(0, 0, 0.8f);

        already_out = true;
    }



}
