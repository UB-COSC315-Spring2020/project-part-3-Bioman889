using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioClip shellSwitch;
    public AudioClip torpCooledDown;
    public AudioClip cantTorp;
    public float timer = 10;
    public bool canPress = true;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // easy enough with this one, it just checks for space input then plays a sound
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(shellSwitch, 1f);
        }

        /* 
         * this is where the fun begins, so this code needs to check if the C key is pressed while checking if torpCoolDown
         * in the Player_Controller script is less than or equal to 10 in order to keep torpedoes from being spammed
         *
        */
        if (Input.GetKeyDown("c"))
        {
            if (GameObject.Find("Player").GetComponent<Player_Controller>().torpCoolDown <= 10)
            {
                canPress = false;
            }
        }
        // this keeps the player from reseting the timer by spamming C
        if (canPress == false)
        {
            timer -= Time.deltaTime;
        }
        // and this gives an audio cue that you can't shoot more torpedoes at the moment
        if (Input.GetKeyDown("c") && timer <=9.9f)
        {
            audioSource.PlayOneShot(cantTorp, 0.5f);
        }
        // and this bit of code enables the ability to fire torpedoes again
        if (timer <= 0) {
            canPress = true;
            timer = 10;
            audioSource.PlayOneShot(torpCooledDown, 1f);
        }
    }
}
