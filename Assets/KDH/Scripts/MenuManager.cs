using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;
    public QuestManager questManager;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menu.activeSelf)
                menu.SetActive(false);
            else
                menu.SetActive(true);
        }
    }
    public void TitileScene()
    {
        SceneManager.LoadScene("타이틀화면"); // 병합하면 수정
    }

    public void Save() // 병합하면  수정
    {
        PlayerPrefs.SetFloat("PlayerPositionX" , player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", player.transform.position.y);
        PlayerPrefs.SetInt("QuestID", questManager.questID);
        PlayerPrefs.SetInt("QuestActionNumber", questManager.questActionNumber);
        PlayerPrefs.Save();

    }

    public void Load() // 병합하면 수정
    {
        if (!PlayerPrefs.HasKey("PlayerPositionX"))
            return;

       float x = PlayerPrefs.GetFloat("PlayerPositionX");
       float y = PlayerPrefs.GetFloat("PlayerPositionY");
       int questID = PlayerPrefs.GetInt("QuestID" , questManager.questID);
       int questActionNumber = PlayerPrefs.GetInt("QuestActionNumber" , questManager.questActionNumber);

        player.transform.position = new Vector2(x, y);
        questManager.questID = questID;
        questManager.questActionNumber = questActionNumber;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
