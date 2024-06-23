using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraits;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        ObjScriptsData();
    }

    private void ObjScriptsData()
    {
        //talk
        talkData.Add(100, new string[] { "처음 보는 얼굴이군 :0", "이곳의 생활은 어떤가:0" });
        talkData.Add(1000, new string[] { "아무것도 들어있지 않다.:0 " });
        talkData.Add(2000, new string[] { "누군가 사용한 흔적이 있는 캡슐이다. :0 " });

        //Quest
        talkData.Add(10 + 100, new string[] { "마을 근처에 있는 상자를 한번 확인 해보게나:0",
            "보물이 들어 있을지도 모르지:0", "상자를 확인하고 나한테 오게:0" });
        talkData.Add(11 + 100, new string[] { "상자를 찾지 못했는가, :0", "근처에 반드시 있을테니 잘 살펴보게 :0" });

        talkData.Add(11 + 1000, new string[] { "기사의 검을 획득했다. :0 " });

        talkData.Add(20 + 100, new string[] { " 내가 잃어버린 검이 그 상자에 들어있었군..:0", " 고맙네 :0" });


        //portrait
        portraitData.Add(100, portraits[0]);

        portraitData.Add(1000, portraits[1]);
        portraitData.Add(2000, portraits[1]);
    }

    public string SendScripts(int idNumber, int talkIndex)
    {
        if (!talkData.ContainsKey(idNumber))
        {
            if (!talkData.ContainsKey(idNumber - idNumber % 10))
                return SendScripts(idNumber - idNumber % 100, talkIndex);
            else
                return SendScripts(idNumber - idNumber % 10, talkIndex);
        }
        if (talkIndex == talkData[idNumber].Length)
        {
            return null;
        }
        else
        {
            return talkData[idNumber][talkIndex];
        }
    }

    public Sprite SendPortrait(int idNumber, int portraitIndex)
    {
        return portraitData[idNumber + portraitIndex];
    }
}
