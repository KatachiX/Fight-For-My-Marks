using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

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

    public bool UseStamina(int amt)
    {
        if (curStamina - amt >= 0)
        {
            curStamina -= amt;
            staminaBar.value = curStamina;

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

    private IEnumerator RechargeStamina()
    {
        while(curStamina < maxStamina)
        {
            curStamina += 1;
            staminaBar.value = curStamina;
            yield return rechargeTick;
        }
        recharge = null;
    }
}