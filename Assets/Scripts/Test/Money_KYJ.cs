using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money_KYJ : MonoBehaviour
{
    public GameObject openShopBtn;

    public TextMeshProUGUI totalScoreTxt;

    public bool isCheck = false;
    public int totalScore = 0;

    public void AddScore()
    {
        totalScore += 10000;
        totalScoreTxt.text = totalScore.ToString();
    }

    public void OnClickMoney()
    {
        AddScore();
    }

    public void OnClickShop()
    {
        if (isCheck == false)
        {
            openShopBtn.SetActive(true);
            isCheck = true;
            Debug.Log("현재 소지금 : " + totalScore);
        }
        else
        {
            openShopBtn.SetActive(false);
            isCheck = false;
        }
    }

    public void OnClickExit()
    {
        openShopBtn.SetActive(false);
        isCheck = false;
    }
}
