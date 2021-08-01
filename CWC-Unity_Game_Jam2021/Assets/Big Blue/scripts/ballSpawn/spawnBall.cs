using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{
    public float spawnTime = 3;
    public float currentTime =0;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + 1 * Time.deltaTime;

        if (currentTime > spawnTime)
        {
            currentTime = 0;
            GameObject newBall = Instantiate(ball);
            newBall.transform.position = transform.position;



        }
    }
}
