using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderU : MonoBehaviour
{
    [System.Serializable]
    public class FolderStats {
        public int curHealth = 50;
        public int damage = 0;
    }

    public FolderStats stats = new FolderStats();
    
    private bool disableAtk = false;
    private WaitForSeconds atkCd = new WaitForSeconds(20f);

    private WaitForSeconds atkCdEnemy = new WaitForSeconds(10f);

    public string Team;

    public GameObject paper;

    IEnumerator startAtkCd()
    {
        disableAtk = true;

        if (Team == "Ally")
        {
            yield return atkCd;
        }
        else
        {
            yield return atkCdEnemy;
        }
        disableAtk = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!disableAtk)
        {
            Instantiate(paper, transform.position, transform.rotation);
            StartCoroutine(startAtkCd());
        }
    }

    public void TakeDamage(int damage)
    {
        stats.curHealth -= damage;
        StartCoroutine(showTakeDamage());
        if (stats.curHealth <= 0)
        {
            StartCoroutine(die());
            if (Team == "Enemy") // Reward player with money upon defeating enemy
            {
                MoneyManager.instance.ChangeMoney(20);
                StaminaBar.instance.AddStamina(0);
            }
        }
    }

    IEnumerator die()
    {
        Moveset moveset = this.gameObject.GetComponent<Moveset>();
        moveset.Die();

        yield return new WaitForSeconds(0.5f);

        GameMaster.Destroy(this.gameObject);
    }

    IEnumerator showTakeDamage()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
