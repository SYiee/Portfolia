using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link_Obj : MonoBehaviour
{
    public string saved_url;
    private static Link_Obj instance = null;
    public static Link_Obj Instance
    {
        get
        {
            if (null == instance) instance = FindObjectOfType<Link_Obj>();
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
        Application.OpenURL(saved_url);
    }

}
