using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ship : MonoBehaviour
{
    public float moveSpeed;
    public GameObject ship;
    public GameObject movePoint1;
    public GameObject movePoint2;
    public static float timer;
    public float timeBeforeMoving;
    public float timeToGo;

    public static bool primedToFire = false;
    public float timeBeforeShooting;
    public float NewTimeBeforeMoving;
    public int moveSpotController;

    private Vector3 movePoints;
    void Start()
    {
        movePoints = transform.position;

        moveSpotController = 1;

        Physics2D.IgnoreLayerCollision(0, 1);

    }

    //this code will drastically change as there is no way to account for ships of the same class to spawn
    //at different times 
    void Update()
    {
        timer += Time.deltaTime;

        MoveToPoints();

        if (gameObject.CompareTag("DD"))
        {
            StartCoroutine(MovingPoints());
        }
    }

    //assigns movement points that are used to move the ship throughout the level
    void MoveToPoints()
    {
        if (gameObject.CompareTag("CL"))
        {
            Vector3 movePointIchi = movePoint1.transform.position;
            Vector3 movePointNi = movePoint2.transform.position;
            if (timer <= timeBeforeMoving)
            {
                movePoints = movePointIchi;
                primedToFire = true;

                if (primedToFire == true)
                {
                    Debug.Log("Ready to Fire");
                }
            }
            else if (timer >= timeBeforeMoving)
            {
                movePoints = movePointNi;
            }
            transform.position = Vector3.MoveTowards(transform.position, movePoints, moveSpeed * Time.deltaTime);
        }

        if (gameObject.CompareTag("BB"))
        {
            if (timer >= 5)
            {
                Vector3 movePointIchi = movePoint1.transform.position;

                movePoints = movePointIchi;

                transform.position = Vector3.MoveTowards(transform.position, movePoints, moveSpeed * Time.deltaTime);
            }
        }
    }

    // changes the position of the ship based on class. the CL and BB are declared using the old method I created. they can be incorperated into this
    // new system using the same gameObject.CompareTag method
    IEnumerator MovingPoints()
    {
        PointController();

        moveSpotController = 1;
        transform.position = Vector3.MoveTowards(transform.position, movePoints, moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(timeBeforeShooting);

        primedToFire = true;

        yield return new WaitForSeconds(NewTimeBeforeMoving);
        primedToFire = false;
        moveSpotController = 2;
        transform.position = Vector3.MoveTowards(transform.position, movePoints, moveSpeed * Time.deltaTime);
        yield break;

    }

    // a switch to keep MovingPoints from glitching up (it still does though)
    public void PointController()
    {
        Vector3 movePointIchi = movePoint1.transform.position;
        Vector3 movePointNi = movePoint2.transform.position;

        switch (moveSpotController)
        {
            case 2:
                movePoints = movePointNi;
                break;
            case 1:
                movePoints = movePointIchi;
                break;
        }
    }
    // stops the ships from firing and destroys them
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Endpoint"))
        {
            Debug.Log("stopped");
            StopCoroutine(MovingPoints());
            Destroy(gameObject);
        }
    }
}
