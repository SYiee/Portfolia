using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public List<GameObject> Characters = new List<GameObject>();

    public GameObject Player;

    int num = 0;
    private Transform Player_Transform;

    private void Start()
    {
        Player_Transform = Player.transform;
    }

    // Start is called before the first frame update
    public void NextCharacter()
    {
        Player_Transform = Player.transform;
        Destroy(Player);
        GameObject newcharacter = Instantiate(Characters[num], Player_Transform.position, Characters[num].transform.rotation);
        Player = newcharacter;
        num = (num + 1) % Characters.Count;
    }

    public void SelectCharacter()
    {

        SceneManager.LoadScene(1);
    }

    void Update()
    {
        
    }
}
