using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                //이동 제한
                MoveBehaviour.Instance.can_move = false;
                //시점 제한
                ThirdPersonOrbitCamBasic.Instance.can_cam_move = false;
            }
            else
            {
                /* 현재 연결된 오브젝트가 아닌 경우는 끌 수 없음 */
                if (CircleColorPicker.Instance.linkedObject.name != this.gameObject.name) return;
                //Cursor.visible = false;
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
            //print(pickerOnOff);
            CircleColorPicker.Instance.gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y+2, transform.position.z));
        }
    }
}
