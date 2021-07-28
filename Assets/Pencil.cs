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
    
    private bool disableAtk;
    private float atkCd = 0f;
    private float cdTime = 1.5f;

    void OnCollisionEnter2D(Collision2D col) 
    {

        Pencil _pencil = col.collider.GetComponent<Pencil>();
        if (_pencil != null)
        {
            _pencil.TakeDamage(stats.damage); // Enemy pencil takes damage, not this pencil
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit(); 
        }
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
        }
    }
}
