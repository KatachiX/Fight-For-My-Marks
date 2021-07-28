using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASM : MonoBehaviour
{
    public float moveSpeed;

    [HideInInspector]
    public bool pathIsClear;

    public LayerMask enemy;

    public Rigidbody2D rb;
    public CircleCollider2D cc;

    // Start is called before the first frame update
    void Start()
    {
        pathIsClear = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pathIsClear || cc.IsTouchingLayers(enemy))
        {
            Move();
        }
        else
        {
            
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
}
