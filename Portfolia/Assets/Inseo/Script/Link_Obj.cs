using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link_Obj : MonoBehaviour
{
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

    public string url;
    public void link(string urll)
    {
        Application.OpenURL(urll);
    }

}
