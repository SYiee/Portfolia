using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_anc_Link : MonoBehaviour
{
    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    bool pickerOnOff = false;

    public string url;

    private static Click_anc_Link instance = null;
    public static Click_anc_Link Instance
    {
        get
        {
            if (null == instance) instance = FindObjectOfType<Click_anc_Link>();
            return instance;
        }
    }

    private void OnMouseUp()
    {
        if ((Time.time - doubleClickedTime) < interval)
        {
            doubleClickedTime = -1.0f;

            if (Link_Obj.Instance.gameObject.activeSelf == false)
            {
                Link_Obj.Instance.saved_url = url;
                pickerOnOff = true;
                Link_Obj.Instance.gameObject.SetActive(true);
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
        Link_Obj.Instance.gameObject.SetActive(false);
        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        MoveBehaviour.Instance.can_move = true;
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
