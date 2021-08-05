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
    private WaitForSeconds atkCd = new WaitForSeconds(10f);

    public LayerMask team;

    public GameObject paper;

    IEnumerator startAtkCd()
    {
        disableAtk = true;

        yield return atkCd;

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
        if (stats.curHealth <= 0)
        {
            GameMaster.Destroy(this.gameObject);
            MoneyManager.instance.ChangeMoney(0);
        }
    }
}
