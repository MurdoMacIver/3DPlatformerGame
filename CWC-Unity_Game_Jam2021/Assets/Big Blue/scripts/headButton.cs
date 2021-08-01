using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headButton : MonoBehaviour
{
    public int hp = 3;
    public float timer;
    float currentTime;
    public Transform unit;
    public GameObject body;
    public Transform bodyspawnpoint;
    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit!");
        if (currentTime > timer)
        {
            //reset timer 
            currentTime = 0;
            //take damage
            hp = hp - 1;
            audioData.Play();
            if (hp < 0)
            {
                print("blue be dead");
                audioData.Play();
                Destroy(unit.gameObject);

                GameObject newbody = Instantiate(body);
                newbody.transform.position = bodyspawnpoint.position;
                newbody.transform.rotation = bodyspawnpoint.rotation;


            }
            // disable damage script

        }

    }
}
