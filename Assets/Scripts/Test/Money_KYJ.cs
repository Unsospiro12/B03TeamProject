using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money_KYJ : MonoBehaviour
{
    public GameObject increaseBtn;

    public TextMeshProUGUI totalScoreTxt;

    int totalScore = 0;

    public void AddScore(int score)
    {
        totalScore += 10000;
        totalScoreTxt.text = totalScore.ToString();
    }

    public void OnClick()
    {
        AddScore(0);
    }
}
