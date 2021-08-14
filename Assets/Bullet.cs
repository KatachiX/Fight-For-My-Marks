using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 15;
    public float moveSpeed;

    public Rigidbody2D rb;
    public CircleCollider2D cc;

    void OnCollisionStay2D(Collision2D col) 
    {
        Base _base = col.collider.GetComponent<Base>();
        if (_base != null)
        {
            _base.TakeDamage(damage); // Enemy base takes damage
            GameMaster.Destroy(this.gameObject);
        }

        Paper _paper = col.collider.GetComponent<Paper>();
        if (_paper != null)
        {
            _paper.TakeDamage(damage); // Enemy paper takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit();
            GameMaster.Destroy(this.gameObject);
        }

        Eraser _eraser = col.collider.GetComponent<Eraser>();
        if (_eraser != null)
        {
            _eraser.TakeDamage(damage); // Enemy Eraser takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit();
            GameMaster.Destroy(this.gameObject);
        }

        Pencil _pencil = col.collider.GetComponent<Pencil>();
        if (_pencil != null)
        {
            _pencil.TakeDamage(damage); // Enemy pencil takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit();
            GameMaster.Destroy(this.gameObject);
        }

        Ruler _ruler = col.collider.GetComponent<Ruler>();
        if (_ruler != null)
        {
            _ruler.TakeDamage(damage); // Enemy ruler takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit();
            GameMaster.Destroy(this.gameObject);
        }

        Stapler _stapler = col.collider.GetComponent<Stapler>();
        if (_stapler != null)
        {
            _stapler.TakeDamage(damage); // Enemy stapler takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit();
            GameMaster.Destroy(this.gameObject);
        }

        FolderU _folder = col.collider.GetComponent<FolderU>();
        if (_folder != null)
        {
            _folder.TakeDamage(damage); // Enemy folder takes damage
            Moveset _moveset = col.collider.GetComponent<Moveset>();
            _moveset.OnHit();
            GameMaster.Destroy(this.gameObject);
        }

        Bullet _Bullet = col.collider.GetComponent<Bullet>();
        if (_Bullet != null)
        {
            GameMaster.Destroy(_Bullet.gameObject);
            GameMaster.Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, 0f);
    }
}
