using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public Rigidbody rigid;
    public float gravity = 3;
    public Vector3 Direction;
    public float speed = 7;
    public float turnspeed = 1;
    public bool isWalking;
    public Animator anim;

    public float wonderTimer = 3;
    public float currentTime = 0;

    public Vector3 lookdirection;
    // Start is called before the first frame update
    void Start()
    {
        Direction = transform.forward;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lookdirection = Vector3.Lerp(transform.forward, Direction, turnspeed * Time.deltaTime);
        
        if (isWalking)
        {
            lookdirection.y = 0;
            transform.LookAt(transform.position + lookdirection);
            Vector3 movement = transform.forward;
            movement.y = -gravity;
            rigid.velocity = (movement * speed);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        currentTime  = currentTime + 1 * Time.deltaTime;

        if (currentTime > wonderTimer)
        {
            Direction = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            Direction = Direction.normalized;
            currentTime = 0;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        //print("turning");
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        //Direction = Direction * -1;
    }


}
