using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fire : MonoBehaviour
{
    public GameObject shell;
    public Rigidbody2D shellRB;
    public float shellSpeed;
    public int timeSetPosition;
    public GameObject player;

    public float rateOfFire = 2;
    public float fireControl = 1f;

    public float timeBetweenFire;
    public int timesToLoopMax;
    private int currentLoop = 1;

    // Update is called once per frame
    void Update()
    {

        // not sure if the for loop functions as I think, but this will begin the firing stage once the varialbe primedToFire is ture
        // not ideal, given that it will be different for each ship that spawns. I'm not sure of a soultion, but I'm still working on that
        if (Move_Ship.primedToFire == true)
        {
            for (currentLoop = 1; currentLoop <= timesToLoopMax; currentLoop++)
            {
                StartCoroutine(FireControl());
            }
        }
        if (Move_Ship.primedToFire == false)
        {
            StopCoroutine(FireControl());
        }
    }
    // fires shells based on the rate of fire
    IEnumerator FireControl()
    {
        if (Time.time - fireControl > 1 / rateOfFire)
        {
            fireControl = Time.time;

            Vector2 playerPos = player.transform.position;
            Rigidbody2D fire = Instantiate(shellRB, transform.position, transform.rotation);
            fire.velocity = -transform.up * shellSpeed;
            yield return new WaitForSeconds(timeBetweenFire);
        }
    }
}
