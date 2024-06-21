using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money_KYJ : MonoBehaviour
{
    public GameObject increaseBtn;
    public GameObject openShopBtn;

    public TextMeshProUGUI totalScoreTxt;

    public bool isCheck = false;
    int totalScore = 0;

    public void AddScore(int score)
    {
        totalScore += 10000;
        totalScoreTxt.text = totalScore.ToString();
    }

    public void OnClickMoney()
    {
        AddScore(0);
    }

    public void OnClickShop()
    {
        if (isCheck == false)
        {
            openShopBtn.SetActive(true);
            isCheck = true;
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
