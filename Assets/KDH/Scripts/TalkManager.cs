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
        talkData.Add(100, new string[] { "ó�� ���� ���̱� :0", "�̰��� ��Ȱ�� ���:0" });
        talkData.Add(1000, new string[] { "�ƹ��͵� ������� �ʴ�.:0 " });
        talkData.Add(2000, new string[] { "�� ĸ���̴�. :0 " });

        //Quest
        talkData.Add(10 + 100, new string[] { "���� ��ó�� �ִ� ���ڸ� �ѹ� Ȯ�� �غ��Գ�:0",
            "������ ��� �������� ����:0", "���ڸ� Ȯ���ϰ� ������ ����:0" , " ��, �׸��� ���ڸ� �� �� �ִ� ���踦 �ְڳ�:0" });
        talkData.Add(11 + 100, new string[] { "���ڸ� ã�� ���ߴ°�, :0", "��ó�� �ݵ�� �����״� �� ���캸�� :0" });

        talkData.Add(11 + 1000, new string[] { "������ ���� ȹ���ߴ�. :0 " });

        talkData.Add(20 + 100, new string[] { " ���� �Ҿ���� ���� �� ���ڿ� ����־���..:0", " ������ :0" });


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
