using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    [System.Serializable]
    public class BaseStats {
        public int curHealth = 200;
    }

    public BaseStats stats = new BaseStats();

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
