using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClick_Color : MonoBehaviour
{
    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    bool pickerOnOff = false;

    private void OnMouseUp()
    {
        if ((Time.time - doubleClickedTime) < interval)
        {
            doubleClickedTime = -1.0f;

            if (CircleColorPicker.Instance.gameObject.activeSelf == false)
            {
                pickerOnOff = true;
                CircleColorPicker.Instance.gameObject.SetActive(true);

                CircleColorPicker.Instance.linkedObject = this.gameObject;
            }
            else
            {
                /* ���� ����� ������Ʈ�� �ƴ� ���� �� �� ���� */
                if (CircleColorPicker.Instance.linkedObject.name != this.gameObject.name) return;

                pickerOnOff = false;
                CircleColorPicker.Instance.gameObject.SetActive(false);
                CircleColorPicker.Instance.linkedObject = null;
            }
        }
        else
        {
            doubleClickedTime = Time.time;
        }
    }

    private void Update()
    {
        if (pickerOnOff)
        {
            CircleColorPicker.Instance.gameObject.transform.position
                = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);
        }
    }
}
