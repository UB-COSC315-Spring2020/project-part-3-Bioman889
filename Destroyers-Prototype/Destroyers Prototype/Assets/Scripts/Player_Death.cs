using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{

    public static bool isDead = false;

     void Start()
    {
        isDead = false;    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if any of the chunks hit the player, it goes to the game over screen and kills the player
        if (other.gameObject.CompareTag("Large Chunk") || other.gameObject.CompareTag("Small Chunk"))
        {
            SceneManager.LoadScene("GameOver");
            isDead = true;
            Destroy(gameObject);
        }
    }
}
