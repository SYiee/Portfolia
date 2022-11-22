using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject EditOffBtn;
    public GameObject ChooseUI;
    public GameObject ScreenInstallText;

    bool activeInventory = false;
    bool activeEditBtn = false;

    void Start()
    {
        inventoryPanel.SetActive(activeInventory);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
            //ȭ�� �̵� ����
            Cursor.visible = activeInventory;
            ThirdPersonOrbitCamBasic.Instance.can_cam_move = !activeInventory;
        }
        if(activeInventory == true || GameObject.Find("ChooseManager").GetComponent<Choose_Object>().is_editmode == true)
        {
            //������ �κ��丮 ����϶��� ȭ����� & Ŀ��
            Cursor.visible = true;
            ThirdPersonOrbitCamBasic.Instance.can_cam_move = false;
        }
    }

    public void CreateChooseUI(int item_type)  // ���� �� �� �ִ� UI ����
    {
        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);

        if (item_type == 8)
        { // ��ũ�� ��ġ�� ��
            ScreenInstallText.SetActive(true);
            Invoke("OffScreenUI", 4f);
        }
        else  // ������ ������Ʈ ��ġ
        {
            ChooseUI.SetActive(true);
            GameObject.Find("ChooseManager").GetComponent<Choose_Object>().UpdateUI(item_type);
        }
    }

    void OffScreenUI()
    {
        ScreenInstallText.SetActive(false);
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
        //ȭ�� �̵� ���� ����
        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        Cursor.visible = false;
    }

    public void BtnEditModeOut()
    {
        Destroy(GameObject.Find("ChooseManager").GetComponent<Choose_Object>().presentobject);
        Debug.Log("��������");
        GameObject.Find("ChooseManager").GetComponent<Choose_Object>().is_editmode = false;

        //ȭ�� �̵� ���� ����
        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        Cursor.visible = false;

        EditOffBtn.SetActive(false);
        ChooseUI.SetActive(false);

        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);
    }
}
