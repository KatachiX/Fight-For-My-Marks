using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{

    [System.Serializable]
    public class BaseStats {
        public int curHealth = 500;

        public int maxHealth = 500;
    }

    public BaseStats stats = new BaseStats();

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = stats.curHealth  + "/" + stats.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        stats.curHealth -= damage;
        StartCoroutine(showTakeDamage());
        if (stats.curHealth <= 0)
        {
            GameMaster.Destroy(this.gameObject);
        }
    }

    IEnumerator showTakeDamage()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
