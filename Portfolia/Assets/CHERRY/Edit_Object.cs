using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edit_Object : MonoBehaviour
{
    public GameObject newobject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                float size = newobject.GetComponent<BoxCollider>().bounds.size.y / 2;
                Debug.Log(size);
                GameObject instance = Instantiate(newobject, hit.transform.position + new Vector3(0, size, 0), hit.transform.rotation);
                Debug.Log(hit.transform.position);
            }
        }
    }
}
