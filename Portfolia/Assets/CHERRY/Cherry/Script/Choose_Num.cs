using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Num : MonoBehaviour
{
    public int num;

    public void ButtonClicked()
    {
        GameObject.Find("ChooseManager").GetComponent<Choose_Object>().UpdateNum(num);
    }
}
