using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : MonoBehaviour
{
    [System.Serializable]
    public class RulerStats {
        public int curHealth = 100;
        public int damage = 10;
    }

    public RulerStats stats = new RulerStats();
    
    private bool disableAtk = false;
    private WaitForSeconds atkCd = new WaitForSeconds(5f);

    public string Team;

    public GameObject hit;

    List<Collider2D> TriggerList = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D col) 
    {
        if(!TriggerList.Contains(col))
        {
            // Only if gameObject is opposite team
            if(this.gameObject.layer != col.gameObject.layer)
            {
                // Add the object to the list
                TriggerList.Add(col);
            }
        }    
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Only if gameObject is opposite team
        if(this.gameObject.layer != col.gameObject.layer)
        {
            //if the object is in the list
            if(TriggerList.Contains(col))
            {
                //remove it from the list
                TriggerList.Remove(col);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) 
    {
        if (TriggerList != null && !disableAtk)
        {
            foreach(Collider2D col in TriggerList)
            {
                Base _base = col.GetComponent<Base>();
                if (_base != null && !disableAtk)
                {
                    hitAnimation(_base.transform);
                    _base.TakeDamage(stats.damage); // Enemy base takes damage
                }

                Paper _paper = col.GetComponent<Paper>();
                if (_paper != null && !disableAtk)
                {
                    hitAnimation(_paper.transform);
                    _paper.TakeDamage(stats.damage); // Enemy paper takes damage
                    Moveset _moveset = col.GetComponent<Moveset>();
                    _moveset.OnHit();
                }

                Eraser _eraser = col.GetComponent<Eraser>();
                if (_eraser != null && !disableAtk)
                {
                    hitAnimation(_eraser.transform);
                    _eraser.TakeDamage(stats.damage); // Enemy Eraser takes damage
                    Moveset _moveset = col.GetComponent<Moveset>();
                    _moveset.OnHit();
                }

                Pencil _pencil = col.GetComponent<Pencil>();
                if (_pencil != null && !disableAtk)
                {
                    hitAnimation(_pencil.transform);
                    _pencil.TakeDamage(stats.damage); // Enemy pencil takes damage
                    Moveset _moveset = col.GetComponent<Moveset>();
                    _moveset.OnHit();
                }

                Ruler _ruler = col.GetComponent<Ruler>();
                if (_ruler != null && !disableAtk)
                {
                    hitAnimation(_ruler.transform);
                    _ruler.TakeDamage(stats.damage); // Enemy ruler takes damage
                    Moveset _moveset = col.GetComponent<Moveset>();
                    _moveset.OnHit(); 
                }

                Stapler _stapler = col.GetComponent<Stapler>();
                if (_stapler != null && !disableAtk)
                {
                    hitAnimation(_stapler.transform);
                    _stapler.TakeDamage(stats.damage); // Enemy stapler takes damage
                    Moveset _moveset = col.GetComponent<Moveset>();
                    _moveset.OnHit();
                }

                FolderU _folderU = col.GetComponent<FolderU>();
                if (_folderU != null && !disableAtk)
                {
                    hitAnimation(_folderU.transform);
                    _folderU.TakeDamage(stats.damage); // Enemy folder takes damage
                    Moveset _moveset = col.GetComponent<Moveset>();
                    _moveset.OnHit(); 
                }
            }
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
            GameMaster.Destroy(this.gameObject);
            if (Team == "Enemy") // Reward player with stamina and money upon defeating enemy
            {
                MoneyManager.instance.ChangeMoney(10);
                StaminaBar.instance.AddStamina(10);
            }
        }
    }

    IEnumerator showTakeDamage()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
