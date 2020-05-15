using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Cube : MonoBehaviour
{
    public GameObject largeChunk;
    public Rigidbody2D largeChunkRB;

    public int maxCubes;
    public static float globalMaxCubes;
    public float cubeSpawnRate;
    public int cubesSpawned;
    public float fallSpeed;
    public float MaxfallSpeed;
    public float cubeSpawnRateMin;
    public int fallSpeedMax;

    // Start is called before the first frame update
    void Start()
    {
        //creates initial force for the chunks
        largeChunkRB.AddForce(-Vector2.up, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //spawns the cubes based on the spawn rate
        globalMaxCubes -= Time.deltaTime;

        if (globalMaxCubes <= 0f && cubesSpawned < maxCubes)
        {
            cubesSpawned++;

            globalMaxCubes = this.cubeSpawnRate;

            StartCoroutine(droppingCubes());
        }

        if (cubesSpawned == maxCubes && fallSpeed <= fallSpeedMax)
        {
            cubesSpawned = 0;
            fallSpeed += 1;
            if (cubeSpawnRate >= cubeSpawnRateMin)
            {
                cubeSpawnRate -= 0.05f;
            }
        }
    }

    IEnumerator droppingCubes()
    {
        //creates the cubes
        Vector3 cubeDispersion = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), Random.Range(0f, 0f));
        yield return new WaitForSeconds(1f);
        Rigidbody2D lgChunk = Instantiate(largeChunkRB, transform.position + cubeDispersion, (transform.rotation));
        lgChunk.velocity = -Vector2.up * (fallSpeed);
    }
}
