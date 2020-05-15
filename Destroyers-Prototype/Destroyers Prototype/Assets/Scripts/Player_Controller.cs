using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public float playerSpeed = 6.0f;
    
    //for the different shell types and funtions
    public GameObject heShell;
    public Rigidbody2D heProjectile;
    public Image heIcon;

    public GameObject apShell;
    public Rigidbody2D apProjectile;
    public Image apIcon;

    public GameObject torpedo;
    public Rigidbody2D torpedoProjectile;
    public Image torpedoIcon;
    public Image torpCoolDownIcon;
    public float torpCoolDown = 0;
    public Text torpCoolDownText;
    public float torpCoolDownTime = 5;
    public Text ammoCounter;

    //controlling the shell types
    public float shellSpeed = 20f;
    public float rateOfFire = 2;
    public float fireControl = 1f;
    private bool shellType;
    public Text shellTypeText;

    // Start is called before the first frame update
    void Start()
    {
        shellType = true;
        shellTypeText.text = ("Shell Type: HE");
        torpCoolDownText.text = ("Torpedo Cooldown: " + Mathf.RoundToInt(torpCoolDown));
        apIcon.enabled = false;
        torpCoolDownIcon.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //player movement on the 2D axis
        var movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * playerSpeed * Time.deltaTime;
        transform.Translate(movement.x, 0, 0);
        transform.Translate(0, movement.y, 0);

        //firing the different shell types
        if (Input.GetKey("z"))
        {
            Fire();
        }
        // keeps the shells from being used at the same time. I plan to have a sound play to signify that
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapShell();
        }

        if (Input.GetKeyDown("c"))
        {
            FireTorp();
        }
        // a bit clunky but does make sure the torpCoolDown is 0 and ready to be used after a cooldown
        if (torpCoolDown != 0f)
        {
            torpCoolDown -= Time.deltaTime;
            torpCoolDownText.text = ("Special Cooldown: " + Mathf.RoundToInt(torpCoolDown));
        }
        if (torpCoolDown <=0f)
        {
            torpCoolDown = 0;
            torpedoIcon.enabled = true;
            torpCoolDownIcon.enabled = false;
        }

        if (Player_Death.isDead == true)
        {
            Destroy(gameObject);
        }

    }

    public void Fire()
    {
        if (shellType == true)
        {
            //this will spawn an instance of the shell that is tied to the the fire rate
            if (Time.time - fireControl > 1 / rateOfFire)
            {
                fireControl = Time.time;
                //offsets the projectile in order to not collide with the player
                Vector3 offset = new Vector3(0f, 1.5f, 0f);

                Rigidbody2D HE = Instantiate(heProjectile, transform.position + offset, transform.rotation);
                HE.velocity = transform.up * (shellSpeed);
            }
        }
        else if (shellType == false)
        {
            if (Time.time - fireControl > 1 / rateOfFire)
            {
                fireControl = Time.time;
                //offsets the projectile in order to not collide with the player
                Vector3 offset = new Vector3(0f, 1.2f, 0f);

                Rigidbody2D AP = Instantiate(apProjectile, transform.position + offset, transform.rotation);
                AP.velocity = transform.up * (shellSpeed);
            }
        }
    }

    public void SwapShell()
    {
        shellType = !shellType;
        if (shellType == true)
        {
            shellTypeText.text = ("Shell Type: HE");
            heIcon.enabled = true;
            apIcon.enabled = false;
        }
        else
        {
            shellTypeText.text = ("Shell Type: AP");
            apIcon.enabled = true;
            heIcon.enabled = false;
        }
    }

    public void FireTorp()
    {
        if (torpCoolDown == 0)
        {

            //creates instances of the torpedoes that spawn in their own positions and go off on their own path
            torpCoolDownIcon.enabled = true;
            torpedoIcon.enabled = false;
            torpCoolDown = torpCoolDownTime;
            Vector3 offset = new Vector3(0f, 1.2f, 0f);
            Vector3 offset2 = new Vector3(0.5f, 1.2f, 0f);
            Vector3 offset3 = new Vector3(-0.5f, 1.2f, 0f);

            Vector2 trajectory1 = new Vector2(-0.2f, 1f);
            Vector2 trajectory2 = new Vector2(0.2f, 1f);

            Rigidbody2D TORP = Instantiate(torpedoProjectile, transform.position + offset, transform.rotation);
            TORP.velocity = transform.up * (shellSpeed);
            Rigidbody2D TORPRight = Instantiate(torpedoProjectile, transform.position + offset2, transform.rotation);
            TORPRight.velocity = trajectory2 * (shellSpeed);
            TORPRight.rotation = 350f;
            Rigidbody2D TORPLeft = Instantiate(torpedoProjectile, transform.position + offset3, transform.rotation);
            TORPLeft.velocity = trajectory1 * (shellSpeed);
            TORPLeft.rotation = 10f;
        }
    }

}
