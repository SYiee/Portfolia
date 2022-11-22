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
            //화면 이동 제한
            Cursor.visible = activeInventory;
            ThirdPersonOrbitCamBasic.Instance.can_cam_move = !activeInventory;
        }
        if(activeInventory == true || GameObject.Find("ChooseManager").GetComponent<Choose_Object>().is_editmode == true)
        {
            //강제로 인벤토리 모드일때는 화면고정 & 커서
            Cursor.visible = true;
            ThirdPersonOrbitCamBasic.Instance.can_cam_move = false;
        }
    }

    public void CreateChooseUI(int item_type)  // 종류 고를 수 있는 UI 생성
    {
        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);

        if (item_type == 8)
        { // 스크린 설치일 때
            ScreenInstallText.SetActive(true);
            Invoke("OffScreenUI", 4f);
        }
        else  // 나머지 오브젝트 설치
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
        //화면 이동 제한 해제
        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        Cursor.visible = false;
    }

    public void BtnEditModeOut()
    {
        Destroy(GameObject.Find("ChooseManager").GetComponent<Choose_Object>().presentobject);
        Debug.Log("없어져라");
        GameObject.Find("ChooseManager").GetComponent<Choose_Object>().is_editmode = false;

        //화면 이동 제한 해제
        ThirdPersonOrbitCamBasic.Instance.can_cam_move = true;
        Cursor.visible = false;

        EditOffBtn.SetActive(false);
        ChooseUI.SetActive(false);

        activeInventory = false;
        inventoryPanel.SetActive(activeInventory);
    }
}
