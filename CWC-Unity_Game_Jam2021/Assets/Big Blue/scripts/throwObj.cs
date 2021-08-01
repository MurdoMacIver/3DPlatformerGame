using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwObj : MonoBehaviour
{
    public carryObject carry;
    public float throwStr = 4;
    public Animator anim;
    public Transform bigBlueChest;
    public float animHeadStart = 2;
    public float delay = 5;
    public float currentTime = 0;
    public float lift;
    public float resetTime = 0;

    public Transform currentTarget;
    public Vector3 targetDirection;
   
    public float aimDelay = 0;
    public targetingSystem targeting;

    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (carry.heldObject != null)
        {

            Vector2 currentDirection = Vector2.Lerp(new Vector2(0, 0), new Vector2(targetDirection.x, targetDirection.z), (currentTime *2) -1);

            anim.SetFloat("X", currentDirection.x);
            anim.SetFloat("Y", currentDirection.y);

            currentTime = currentTime + 1 * Time.deltaTime;

            if (currentTime >= delay - animHeadStart)
            {
                targeting.currentRamp = Random.Range(0,targeting.ramps.Length-1);
                //
                audioData.Play();
                carry.enabled = false;
                anim.SetBool("isHolding", false);


                if (currentTime >= delay)
                {
                    Vector3 throwingArk = (bigBlueChest.up);
                    throwingArk.y = 0;
                    throwingArk.y = throwingArk.y + lift;
                    carry.heldObject.letgo();
                    carry.heldObject.rigidbody.AddForce(throwingArk * throwStr);
                    carry.heldObject = null;
                    resetTime = 0;
                }
            }
        } else
        {
            //print("test");
            
            resetTime = resetTime + 1 * Time.deltaTime;
            Vector2 currentDirection = Vector2.Lerp( new Vector2(targetDirection.x, targetDirection.y), new Vector2(0, 0), resetTime-1);
            anim.SetFloat("X", currentDirection.x);
            anim.SetFloat("Y", currentDirection.y);

            if (resetTime >= delay)
             {
                currentTime = 0;
                carry.enabled = true;
             }
        }

        // Targeting
        if (currentTarget == null)
        {
            if (currentTime < delay - animHeadStart)
            {
                targetDirection = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
                targetDirection = targetDirection.normalized;
                
            }
                
        }
        else
        {
            targetDirection = currentTarget.localPosition;
            targetDirection = targetDirection.normalized;
        }
        // targeting end

    }

}

