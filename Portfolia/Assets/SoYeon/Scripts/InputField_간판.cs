using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputField_°£ÆÇ : MonoBehaviour
{
    public GameObject InputField_Title;
    public GameObject inputtext;
    public InputField field;
    public GameObject present_panel;

    string title;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GetTitleText()
    {
        title = inputtext.GetComponent<Text>().text;
        present_panel.GetComponent<TextMeshProUGUI>().text = title;

        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        Debug.Log("dkdfkdflak");

        gameObject.SetActive(false);
        Debug.Log("dkdfkdflak");

        field.Select();
        field.text = "";
        title = "";

    }
}
