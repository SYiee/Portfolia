using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject Panel_UI;
    public GameObject Title;

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
            ThirdPersonOrbitCamBasic.Instance.can_cam_move = false;

            Panel_UI.SetActive(true);
            Panel_UI.GetComponent<InputField_간판>().present_panel = Title;
            Cursor.visible = true;
            isDoubleClicked = false;
        }
    }
}
