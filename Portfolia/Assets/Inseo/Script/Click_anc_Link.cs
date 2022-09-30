using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_anc_Link : MonoBehaviour
{
    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    bool pickerOnOff = false;


    private void OnMouseUp()
    {
        if ((Time.time - doubleClickedTime) < interval)
        {
            doubleClickedTime = -1.0f;

            if (Link_Obj.Instance.gameObject.activeSelf == false)
            {
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
