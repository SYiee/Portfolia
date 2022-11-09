using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject EditOffBtn;
    public GameObject ChooseUI;

    bool activeInventory = false;
    bool activeEditBtn = false;

    void Start()
    {
        inventoryPanel.SetActive(activeInventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Cursor.visible = true;
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);

        }
    }

    public void CreateChooseUI(int item_type)  // ���� �� �� �ִ� UI ����
    {
        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);
        ChooseUI.SetActive(true);
        GameObject.Find("ChooseManager").GetComponent<Choose_Object>().UpdateUI(item_type);
    }

    public void BacktoInventoryUI()
    {
        activeInventory = true;
        inventoryPanel.SetActive(true);
        ChooseUI.SetActive(false);
    }

    public void EditMode()
    {
        ChooseUI.SetActive(false);
        EditOffBtn.SetActive(true);
        GameObject.Find("ChooseManager").GetComponent<Choose_Object>().is_editmode = true;
    }

    public void EditModeOut()
    {
        activeEditBtn = !activeEditBtn;
        EditOffBtn.SetActive(false);
        GameObject.Find("ChooseManager").GetComponent<Choose_Object>().is_editmode = false;
    }

    public void BtnEditModeOut()
    {
        Destroy(GameObject.Find("ChooseManager").GetComponent<Choose_Object>().presentobject);
        Debug.Log("��������");
        GameObject.Find("ChooseManager").GetComponent<Choose_Object>().is_editmode = false;

        EditOffBtn.SetActive(false);
        ChooseUI.SetActive(false);

        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);
    }
}
