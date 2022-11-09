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

    public GameObject presentobject;
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
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Floor" || hit.collider.tag == "Object") { 

                    present_hit = hit;
                    if (is_first_spawn)
                    {
                    
                        Debug.Log("첫 생성");
                        float size = objectArray[objnum].objects[roomnum].GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                        float size2 = hit.transform.GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                        Debug.Log(size2);
                    
                        presentobject = Instantiate(objectArray[objnum].objects[roomnum], hit.transform.position + new Vector3(0, size + size2 + 1, 0), objectArray[objnum].objects[roomnum].transform.rotation);

                        RigidSetting(presentobject);

                        is_first_spawn = false;
                    }
                    else
                    {
                        ChangetoWhite(presentobject);
                        float size = objectArray[objnum].objects[roomnum].GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                        float size2 = hit.transform.GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                        Debug.Log(size2);

                        if (hit.transform.GetComponentInChildren<BoxCollider>().transform != presentobject.transform.GetComponentInChildren<BoxCollider>().transform)
                            presentobject.transform.position = hit.transform.position + new Vector3(0, size + size2 + 1, 0);
                    }
                }
                else
                {
                    if (!is_first_spawn && hit.transform != presentobject.transform)
                    {
                        ChangetoRed(presentobject);
                    }
                }
            }
            
        }
        
        if (Input.GetMouseButtonDown(0) && is_editmode)  // 물체 생성하기
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != presentobject.transform)
                {
                    Destroy(presentobject);
                    if (hit.collider.tag == "Floor" || hit.collider.tag == "Object")
                    {
                        is_first_spawn = true;
                        float size = objectArray[objnum].objects[roomnum].GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                        float size2 = present_hit.transform.GetComponentInChildren<BoxCollider>().bounds.size.y / 2;
                        Debug.Log("size1");

                        GameObject instance = Instantiate(objectArray[objnum].objects[roomnum], hit.transform.position + new Vector3(0, size + size2 + 1, 0), objectArray[objnum].objects[roomnum].transform.rotation);

                        RigidSetting(instance);

                    }
                }
                else {
                    presentobject = null;
                }

                // instance.GetComponent<Rigidbody>().isKinematic = true;
            }

            is_first_spawn = true;

            GameObject.Find("InventoryManager").GetComponentInChildren<InventoryUI>().EditModeOut();

        }
    }

    void RigidSetting(GameObject obj)
    {
        if (obj.GetComponent<MeshCollider>() != null)
        {
            obj.GetComponent<MeshCollider>().convex = true;
        }
        if (obj.GetComponentInChildren<MeshCollider>() != null)
        {
            obj.GetComponentInChildren<MeshCollider>().convex = true;
        }

        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().mass = 100000;
        obj.GetComponent<Rigidbody>().freezeRotation = true;
    }

    void ChangetoRed(GameObject obj)
    {
        if (obj.GetComponent<MeshRenderer>() != null)
        {
            obj.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (obj.GetComponentInChildren<MeshRenderer>() != null)
        {
            obj.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }

    void ChangetoWhite(GameObject obj)
    {
        if (obj.GetComponent<MeshRenderer>() != null)
        {
            obj.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        if (obj.GetComponentInChildren<MeshRenderer>() != null)
        {
            obj.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
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
