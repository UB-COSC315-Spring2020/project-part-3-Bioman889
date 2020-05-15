using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Controller : MonoBehaviour
{

    public GameObject ship;
    public int health;
    public static bool heavyArmor;
    public int damageTaken;

    // Start is called before the first frame update
    void Start()
    {

        //sets each ship class's health and armor state
        Physics2D.IgnoreLayerCollision(0, 8);

        if (gameObject.CompareTag("DD"))
        {
            heavyArmor = false;
            health = 3;
        }

        if (gameObject.CompareTag("CA"))
        {
            heavyArmor = true;
            health = 7;
        }
        if (gameObject.CompareTag("CL"))
        {
            heavyArmor = false;
            health = 5;
        }
        if (gameObject.CompareTag("BB"))
        {
            heavyArmor = true;
            health = 10;
        }
        if (gameObject.CompareTag("CV"))
        {
            heavyArmor = false;
            health = 8;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //on collision, this code checks to see if heavy armor is true. if it is, HE shells do half damage and AP does normal
        if (heavyArmor == true)
        {
            if (collision.gameObject.CompareTag("AP Shell"))
            {
                damageTaken = Projectile_Manager.damage;
                health -= damageTaken;
                Debug.Log(health);
                if (health <= 0)
                {
                    Debug.Log(health);
                    Destroy(gameObject);
                }
            }
            if (collision.gameObject.CompareTag("HE Shell"))
            {
                damageTaken = (Projectile_Manager.damage / 2);
                health -= damageTaken;
                Debug.Log(health);
                if (health <= 0)
                {
                    Debug.Log(health);
                    Destroy(gameObject);
                }
            }
        }
        else if (heavyArmor == false)
        {
            if (collision.gameObject.CompareTag("HE Shell"))
            {
                damageTaken = Projectile_Manager.damage;
                health -= damageTaken;
                Debug.Log(health);
                if (health <= 0)
                {
                    Debug.Log(health);
                    Destroy(gameObject);
                }
            }
            if (collision.gameObject.CompareTag("AP Shell"))
            {
                damageTaken = (Projectile_Manager.damage / 2);
                health -= damageTaken;
                Debug.Log(health);
                if (health <= 0)
                {
                    Debug.Log(health);
                    Destroy(gameObject);
                }
            }
        }
    }
}
