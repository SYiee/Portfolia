using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom_LinkUI : MonoBehaviour
{

    public string saved_url;
    private static Custom_LinkUI instance = null;
    public static Custom_LinkUI Instance
    {
        get
        {
            if (null == instance) instance = FindObjectOfType<Custom_LinkUI>();
            return instance;
        }
    }

    private void Awake()
    {
        if (null == instance) instance = this;
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private string url;
    public void link()
    {
        saved_url = Custom_Link.Instance.inputfield_.text;
        Application.OpenURL(saved_url);
        Custom_Link.Instance.pickerOnOff = false;
        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        MoveBehaviour.Instance.can_move = true;
        Custom_LinkUI.Instance.gameObject.SetActive(false);
    }
}
