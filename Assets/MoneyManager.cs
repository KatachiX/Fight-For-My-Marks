using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
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

    public bool UseMoney (int moneyValue)
    {
        if (moneyValue <= money)
        {
            money -= moneyValue;
            text.text = money.ToString();
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }
    }
}
