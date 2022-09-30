using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edit_Type_Btn : MonoBehaviour
{
    public int item_type;

    public void CreateUI()
    {
        GameObject.Find("InventoryManager").GetComponent<InventoryUI>().CreateChooseUI(item_type);
    }
}
