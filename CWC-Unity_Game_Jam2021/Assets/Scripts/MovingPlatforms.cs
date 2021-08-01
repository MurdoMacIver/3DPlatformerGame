using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    float speed = 3f;

    int targetIndex = 0;

    bool moveTowards = true;

    Vector3 currentTarget;

    [SerializeField]
    Vector3[] targets;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = targets[targetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (transform.position == currentTarget)
        {
            if (targetIndex == 0)
                moveTowards = true;
            else if (targetIndex == targets.Length - 1)
                moveTowards = false;

            if (moveTowards)
                targetIndex++;
            else
                targetIndex--;

            currentTarget = targets[targetIndex];
        }
    }
}
