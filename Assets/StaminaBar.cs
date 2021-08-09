using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    public TextMeshProUGUI text;

    private int maxStamina = 100;
    private int curStamina;

    private WaitForSeconds rechargeTick = new WaitForSeconds(0.5f);
    private Coroutine recharge;

    public static StaminaBar instance;

    private void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        curStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    void Update()
    {
        text.text = curStamina + "/" + maxStamina;
        staminaBar.value = curStamina;
    }

    public bool UseStamina(int amt)
    {
        if (curStamina - amt >= 0)
        {
            curStamina -= amt;

            if (recharge != null)
            {
                StopCoroutine(recharge);
            }

            recharge = StartCoroutine(RechargeStamina());

            return true;
        }
        else
        {
            Debug.Log("Not enough stamina");
            return false;
        }
    }

    public void AddStamina(int amt)
    {
        if(curStamina + amt > maxStamina)
        {
            curStamina = maxStamina;
        }
        else
        {
            curStamina += amt;
        }
    }

    private IEnumerator RechargeStamina()
    {
        while(curStamina < maxStamina)
        {
            curStamina += 1;
            yield return rechargeTick;
        }
        recharge = null;
    }
}
