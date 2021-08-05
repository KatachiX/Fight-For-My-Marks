using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int money;
     
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            money = 0;
        }   
    }

    public void ChangeMoney(int moneyValue)
    {
        money += moneyValue;
        text.text = money.ToString();
    }
}
