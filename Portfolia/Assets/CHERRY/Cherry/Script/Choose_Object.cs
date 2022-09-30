using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class ObjectArray
{
    public GameObject[] objects;
}

[System.Serializable]
public class ImageArray //행에 해당되는 이름
{
    public Sprite[] imgs;
}

public class Choose_Object : MonoBehaviour
{
    public ObjectArray[] objectArray;
    public ImageArray[] imgArray;
    public TextMeshProUGUI Titletest;
    public List<Button> Buttons = new List<Button>();


    //  public List<GameObject> newobject = new List<GameObject>();
    //   public List<GameObject> exobject = new List<GameObject>();

    private GameObject presentobject;
    RaycastHit present_hit;

    public bool is_editmode = false;
    bool is_first_spawn = true;
    int objnum;
    int roomnum;

    enum Items { DESK, CHAIR, COMPUTER, FOOD, BIG, CONTROLLER, DESKITEM, FLOEWRPOT};

    // Update is called once per frame
    void Update()
    {
        if (is_editmode)  // 생성할 물체 미리보기
        {
            Debug.Log("edit mode");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Floor")
            {
                present_hit = hit;
                if (is_first_spawn)
                {
                    is_first_spawn = false;
                    Debug.Log("첫 생성");
                    float size = objectArray[objnum].objects[roomnum].GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                    float size2 = hit.transform.GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                    Debug.Log(size2);
                    presentobject = Instantiate(objectArray[objnum].objects[roomnum], hit.transform.position + new Vector3(0, size + size2, 0), objectArray[objnum].objects[roomnum].transform.rotation);
                }
                else
                {
                    float size = objectArray[objnum].objects[roomnum].GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                    float size2 = hit.transform.GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                    Debug.Log(size2);

                    if (hit.transform.GetComponentInChildren<BoxCollider>().transform != presentobject.transform.GetComponentInChildren<BoxCollider>().transform)
                        presentobject.transform.position = hit.transform.position + new Vector3(0, size + size2, 0);
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && is_editmode)  // 물체 생성하기
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))  
            {
                Destroy(presentobject);
                is_first_spawn = true;
                float size = objectArray[objnum].objects[roomnum].GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                float size2 = present_hit.transform.GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                Debug.Log("size1");
                GameObject instance = Instantiate(objectArray[objnum].objects[roomnum], hit.transform.position + new Vector3(0, size + size2, 0), objectArray[objnum].objects[roomnum].transform.rotation);
                Debug.Log(hit.transform.position);
                GameObject.Find("InventoryManager").GetComponentInChildren<InventoryUI>().EditModeOut();
            }
        }
    }


    public void UpdateUI(int obj_type)
    {
        objnum = obj_type;
        Items item;
        item = (Items)obj_type;
        Debug.Log(item);
        Titletest.text = item.ToString();

        for(int i=0; i< Buttons.Count; i++)
            Buttons[i].GetComponent<Image>().sprite = imgArray[objnum].imgs[i];
    }

    public void UpdateNum(int num)
    {
        roomnum = num;
    }

}
