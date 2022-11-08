using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Characters;
    private GameObject Selected_Player;
    public Camera MainCamera;

    void Start()
    {
        
        Characters[StartManager.character_num].GetComponent<BasicBehaviour>().enabled = true;
        Characters[StartManager.character_num].GetComponent<BasicBehaviour>().playerCamera = MainCamera.transform;
        Selected_Player = Instantiate(Characters[StartManager.character_num]);
        //Selected_Player.GetComponent<BasicBehaviour>().enabled = true;
        //Selected_Player.GetComponent<BasicBehaviour>().playerCamera = MainCamera.transform;

        MainCamera.GetComponent<ThirdPersonOrbitCamBasic>().player = Selected_Player.transform;
        MainCamera.GetComponent<ThirdPersonOrbitCamBasic>().PlayStart();
        MainCamera.GetComponent<ThirdPersonOrbitCamBasic>().enabled = true;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
