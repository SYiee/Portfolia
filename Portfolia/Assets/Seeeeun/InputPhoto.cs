using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class InputPhoto : MonoBehaviour
{
    public string url;
    public GameObject inputurl;
    public GameObject inputField;
    public InputField Field;
    public GameObject btn;
    private string str = "";
    Shader shader;

    [SerializeField] Material _material;
    Texture2D _texture;

    private void Start()
    {

        //GetIMG();
    }


    public void StoreName()
    {
        url = inputurl.GetComponent<Text>().text;
        StartCoroutine(DownloadImage(url));
        //_texture = await GetRemoteTexture(inputurl.GetComponent<Text>().text);
        //_material.mainTexture = _texture;

        Debug.Log(url);

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

    public static async Task<Texture2D> GetRemoteTexture(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz

            // read results:
            //if (www.isNetworkError || www.isHttpError)
            if( www.result!=UnityWebRequest.Result.Success )// for Unity >= 2020.1
            {
                // log error:
                #if DEBUG
                Debug.Log($"{www.error}, URL:{www.url}");
                #endif

                // nothing to return on error:
                return null;
            }
            else
            {
                // return valid results:
                return DownloadHandlerTexture.GetContent(www);
            }
        }
    }


}