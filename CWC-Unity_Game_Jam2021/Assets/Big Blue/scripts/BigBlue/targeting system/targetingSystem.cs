using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetingSystem : MonoBehaviour
{
    public Transform retical;
    public Transform player;
    public Transform currentTarget;
    public float targetRange = 15;
    public Transform[] ramps;
    public int currentRamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            float playerDist = Vector3.Distance(transform.position, player.position);
            if (playerDist < targetRange)
            {
                currentTarget = player;
            }
            else
            {
                //print("test");
                currentTarget = ramps[currentRamp];
            }
            retical.position = currentTarget.position;
        }
    }
}
