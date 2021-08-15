using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [System.Serializable]
    public class PaperStats {
        public int curHealth = 200;
        public int damage = 6;
    }

    public PaperStats stats = new PaperStats();
    
    private bool disableAtk = false;
    private WaitForSeconds atkCd = new WaitForSeconds(3f);

    public string Team;

    public GameObject hit;

    void OnCollisionStay2D(Collision2D col) 
    {
        Base _base = col.collider.GetComponent<Base>();
        if (_base != null && !disableAtk)
        {
            hitAnimation(_base.transform);
            _base.TakeDamage(stats.damage); // Enemy base takes damage
            StartCoroutine(startAtkCd());
        }

        Paper _paper = col.collider.GetComponent<Paper>();
        if (_paper != null && !disableAtk)
        {
            hitAnimation(_paper.transform);
            _paper.TakeDamage(stats.damage); // Enemy paper takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit(); 
            StartCoroutine(startAtkCd());
        }

        Eraser _eraser = col.collider.GetComponent<Eraser>();
        if (_eraser != null && !disableAtk)
        {
            hitAnimation(_eraser.transform);
            _eraser.TakeDamage(stats.damage * 3); // Enemy Eraser takes damage * 3
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit(); 
            StartCoroutine(startAtkCd());
        }

        Pencil _pencil = col.collider.GetComponent<Pencil>();
        if (_pencil != null && !disableAtk)
        {
            hitAnimation(_pencil.transform);
            _pencil.TakeDamage(stats.damage / 2); // Enemy pencil takes damage / 2
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit(); 
            StartCoroutine(startAtkCd());
        }

        Ruler _ruler = col.collider.GetComponent<Ruler>();
        if (_ruler != null && !disableAtk)
        {
            hitAnimation(_ruler.transform);
            _ruler.TakeDamage(stats.damage); // Enemy ruler takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit(); 
            StartCoroutine(startAtkCd());
        }

        Stapler _stapler = col.collider.GetComponent<Stapler>();
        if (_stapler != null && !disableAtk)
        {
            hitAnimation(_stapler.transform);
            _stapler.TakeDamage(stats.damage); // Enemy stapler takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit();
            StartCoroutine(startAtkCd());
        }

        FolderU _folderU = col.collider.GetComponent<FolderU>();
        if (_folderU != null && !disableAtk)
        {
            hitAnimation(_folderU.transform);
            _folderU.TakeDamage(stats.damage); // Enemy folder takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit();
            StartCoroutine(startAtkCd());
        }
    }

    void hitAnimation(Transform t)
    {
        Instantiate(hit, t.position, t.rotation);
    }

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
        
    }

    public void TakeDamage(int damage)
    {
        stats.curHealth -= damage;
        StartCoroutine(showTakeDamage());
        if (stats.curHealth <= 0)
        {
            StartCoroutine(die());
            if (Team == "Enemy") // Reward player with stamina and money upon defeating enemy
            {
                MoneyManager.instance.ChangeMoney(10);
                StaminaBar.instance.AddStamina(10);
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
