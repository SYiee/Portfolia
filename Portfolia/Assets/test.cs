using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    Text mText;
    // Start is called before the first frame update
    void Start()
    {
        mText = GetComponent<Text>();
        Invoke("test_", 3);   
    }


    void test_()
    {
        mText.horizontalOverflow = HorizontalWrapMode.Overflow;
    }
    // Update is called once per frame
    void Update()
    {
        if (mText.horizontalOverflow != HorizontalWrapMode.Overflow) 
        {
            mText.horizontalOverflow = HorizontalWrapMode.Overflow;
        }
    }
}
