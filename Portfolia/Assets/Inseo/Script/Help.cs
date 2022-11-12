using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject help_panel;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            help_panel.SetActive(true);
        }
        else
        {
            help_panel.SetActive(false);
        }
    }
}
