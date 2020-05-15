using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Manager: MonoBehaviour
{
    public GameObject Shell;
    public Rigidbody ShellRB;
    public Transform ShellsPrefab;
    public static int damage;
    public bool canBreak;

    void Start()
    {
        // a way for the torpedo's to not collide with the shells
        Physics2D.IgnoreLayerCollision(0, 8);
        damage = 2;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //a way to keep the shells from interacting with the player and themselves
        if (collision.gameObject.tag != "HE Shell" || collision.gameObject.tag != "Player" || collision.gameObject.tag != "AP Shell")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "HE Shell" || collision.gameObject.tag != "AP Shell")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //keeps the number of shells to a minimum
        if (other.gameObject.CompareTag("ProjectileRemover"))
        {
           Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("CA") || other.gameObject.CompareTag("DD") || other.gameObject.CompareTag("BB"))
        {
            Destroy(gameObject);
        }
    }

}
