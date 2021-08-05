using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour
{
    [System.Serializable]
    public class PencilStats {
        public int curHealth = 100;
        public int damage = 10;
    }

    public PencilStats stats = new PencilStats();
    
    private bool disableAtk = false;
    private WaitForSeconds atkCd = new WaitForSeconds(5f);

    public LayerMask team;

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
            _paper.TakeDamage(stats.damage * 3); // Enemy paper takes damage * 3
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit(); 
            StartCoroutine(startAtkCd());
        }

                Eraser _eraser = col.collider.GetComponent<Eraser>();
        if (_eraser != null && !disableAtk)
        {
            hitAnimation(_eraser.transform);
            _eraser.TakeDamage(stats.damage / 2); // Enemy Eraser takes damage / 2
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit(); 
            StartCoroutine(startAtkCd());
        }

        Pencil _pencil = col.collider.GetComponent<Pencil>();
        if (_pencil != null && !disableAtk)
        {
            hitAnimation(_pencil.transform);
            _pencil.TakeDamage(stats.damage); // Enemy pencil takes damage
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

    private void resetAtk()
    {
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
        if (stats.curHealth <= 0)
        {
            GameMaster.Destroy(this.gameObject);
            ScoreManager.instance.ChangeMoney(30);
        }
    }
}
