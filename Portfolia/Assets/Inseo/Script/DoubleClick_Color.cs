using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoubleClick_Color : MonoBehaviour
{
    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    public bool pickerOnOff = false;

    private void OnMouseUp()
    {
        if ((Time.time - doubleClickedTime) < interval)
        {
            doubleClickedTime = -1.0f;
            if (CircleColorPicker.Instance.gameObject.activeSelf == false)
            {
                Cursor.visible = true;
                pickerOnOff = true;
                CircleColorPicker.Instance.gameObject.SetActive(true);
                CircleColorPicker.Instance.linkedObject = this.gameObject;
                //�̵� ����
                MoveBehaviour.Instance.can_move = false;
                //���� ����
                ThirdPersonOrbitCamBasic.Instance.can_cam_move = false;
            }
            else
            {
                /* ���� ����� ������Ʈ�� �ƴ� ���� �� �� ���� */
                if (CircleColorPicker.Instance.linkedObject.name != this.gameObject.name) return;
                Cursor.visible = true;
                pickerOnOff = false;
                CircleColorPicker.Instance.gameObject.SetActive(false);
                CircleColorPicker.Instance.linkedObject = null;
                ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
                MoveBehaviour.Instance.can_move = true;
            }
        }
        else
        {
            doubleClickedTime = Time.time;
        }

    }

    private void Update()
    {
        //print(ThirdPersonOrbitCamBasic.Instance.can_cam_move);
        if (pickerOnOff)
        {
            ThirdPersonOrbitCamBasic.Instance.can_cam_move = false;
            Cursor.visible = true;
            //print(pickerOnOff);
            CircleColorPicker.Instance.gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y+2, transform.position.z));
        }
    }

}
