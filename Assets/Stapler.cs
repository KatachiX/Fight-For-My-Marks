using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stapler : MonoBehaviour
{
    [System.Serializable]
    public class StaplerStats {
        public int curHealth = 100;
    }

    public StaplerStats stats = new StaplerStats();

    private float distToEnemy;
    
    private bool disableAtk = false;
    private WaitForSeconds atkCd = new WaitForSeconds(5f);

    public LayerMask team;
    public LayerMask enemy;
    public Collider2D fireDetection;
    public GameObject Unit;
    public GameObject Bullet;

    Moveset moveset;

    void OnTriggerStay2D(Collider2D col) 
    {
        
        if (col.gameObject.layer != this.gameObject.layer)
        {
            if (!disableAtk)
            {
                StartCoroutine(startAtkCd());
            }
        }
    }

    IEnumerator startAtkCd()
    {
        disableAtk = true;

        Instantiate(Bullet, transform.position, transform.rotation);
        Unit.GetComponent<Moveset>().PauseMove();

        yield return atkCd;

        disableAtk = false;
        Unit.GetComponent<Moveset>().ResumeMove();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.Destroy(this.gameObject);
            MoneyManager.instance.ChangeMoney(70);
        }
    }
}