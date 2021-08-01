using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carryObject : MonoBehaviour
{
    public float acceptableDist = 8;
    public walk thisWalk;
    public float grabDist = 3;
    public Animator anim;
    public Transform grabPoint;
    public throwable heldObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getBall();
        if (heldObject != null)
        {
            thisWalk.isWalking = false;
        }
        else
        {
            thisWalk.isWalking = true;
        }
    }
    void getBall()
    {
        throwable[] barrels = FindObjectsOfType<throwable>();
        float bestdist = Mathf.Infinity;
        if (barrels.Length != 0)
        {
            throwable theOneBarrel = barrels[0]; // the one barrel to rule them all.
            // find closest barrel
            for (int i = 0; i < barrels.Length; i++)
            {
                // it is important to elimate the Y axis
                Vector2 barrelXZ = new Vector2(barrels[i].transform.position.x, barrels[i].transform.position.z);
                Vector2 unitXZ = new Vector2(transform.position.x, transform.position.z);
                float distance = Vector2.Distance(barrelXZ, unitXZ);

                if (distance < bestdist)
                {
                    bestdist = distance;
                    theOneBarrel = barrels[i];
                }
            }
            if (bestdist > acceptableDist)
            {
                //aiWonder();
            }
            else
            {

                if (bestdist <= grabDist + 0.3)
                {
                    grabBall(theOneBarrel);
                }
                else
                {
                    thisWalk.Direction =((theOneBarrel.transform.position - transform.position).normalized);
                }

            }

        }
        else
        {
            //aiWonder();
        }

    }
    void grabBall(throwable ball)
    {
        heldObject = ball;
        //current = timer;

        ball.lockPhysics(grabPoint);
        anim.SetBool("isHolding", true);

    }
}
