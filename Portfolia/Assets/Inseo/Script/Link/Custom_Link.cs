using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom_Link : MonoBehaviour
{
    public InputField inputfield_;
    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    public bool pickerOnOff = false;

    public string url;

    private static Custom_Link instance = null;
    public static Custom_Link Instance
    {
        get
        {
            if (null == instance) instance = FindObjectOfType<Custom_Link>();
            return instance;
        }
    }

    private void OnMouseUp()
    {
        if ((Time.time - doubleClickedTime) < interval)
        {
            doubleClickedTime = -1.0f;

            if (Custom_LinkUI.Instance.gameObject.activeSelf == false)
            {
                pickerOnOff = true;
                Custom_LinkUI.Instance.gameObject.SetActive(true);
                ThirdPersonOrbitCamBasic.Instance.can_cam_move = false;
                MoveBehaviour.Instance.can_move = false;

            }
        }
        else
        {
            doubleClickedTime = Time.time;
        }

    }

    public void linked()
    {
        pickerOnOff = false;
        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        MoveBehaviour.Instance.can_move = true;
        Custom_LinkUI.Instance.gameObject.SetActive(false);
        //Application.OpenURL(url);
    }

    private void Update()
    {
        //if (pickerOnOff)
        //{
        //    CircleColorPicker.Instance.gameObject.transform.position
        //        = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
        //}
    }
}
