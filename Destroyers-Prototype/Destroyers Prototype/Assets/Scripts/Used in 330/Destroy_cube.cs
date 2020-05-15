using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_cube : MonoBehaviour
{
    public GameObject smallerChunk;
    public Rigidbody2D smallerChunkRB;
    public Rigidbody2D largeChunk;

    // Start is called before the first frame update
    void Start()
    {
        //creates random ranges for the cubes to move
        Vector2 explode = new Vector2(Random.Range(-4f, -1f), Random.Range(-2, 2f));
        largeChunk.AddForce(-Vector2.up, ForceMode2D.Impulse);
        smallerChunkRB.AddForce(-Vector2.up * explode, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Cube Breaker"))
        {
            //removes score due to cubes reaching the bottom
            Destroy(gameObject);
            Scoring.score -= Scoring.minusScore;
        }

        //creates offset and velocity variables to control the position and speed of the chunks
        Vector3 offset = new Vector3(0.4f, 0f, 0f);
        Vector3 offset2 = new Vector3(-0.4f, 0f, 0f);

        Vector2 cubeVelocity = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-4.0f, -2.0f));
        Vector2 cubeVelocity2 = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-4.0f, -2.0f));


        if (other.gameObject.CompareTag("Shell"))
    {
            //creates the smaller chunks from the larger one
        if (this.gameObject.CompareTag("Large Chunk"))
        {
            Drop_Cube.globalMaxCubes -= 1;

            Rigidbody2D smallC1 = Instantiate(smallerChunkRB, transform.position, (transform.rotation));
                smallC1.velocity = cubeVelocity;
            Rigidbody2D smallC2 = Instantiate(smallerChunkRB, transform.position, (transform.rotation));
                smallC2.velocity = cubeVelocity2;

            smallerChunkRB.AddForce(-Vector2.up * 3000);
        }

        //removes the chunks and adds the the score
        Destroy(gameObject);
            Scoring.score += Scoring.pointValue;
    }
        
    }
}
