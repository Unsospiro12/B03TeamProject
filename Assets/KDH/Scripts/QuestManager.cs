using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questID;
    public int questActionIndex;

    Dictionary<int, QuestData> questList; 
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        sendData();
    }

    private void sendData()
    {
        questList.Add(10, new QuestData("오브젝트 상호 작용 퀘스트" , new int[] {100 , 1000}));
        questList.Add(20, new QuestData(" 퀘스트 확인", new int[] { 0 }));
    }

    public int QuestTalkIndex(int idNumber)
    {
        return questID + questActionIndex;
    }

    public string CheckQuest(int idNumber)
    {
        if(idNumber == questList[questID].npcIDNumber[questActionIndex])
        questActionIndex++;

        if (questActionIndex == questList[questID].npcIDNumber.Length)
            NextQuest();

        return questList[questID].questName;
    }
    void NextQuest()
    {
        questID += 10;
        questActionIndex = 0;
    }
}
