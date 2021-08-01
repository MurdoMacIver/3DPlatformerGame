using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwable : MonoBehaviour
{
    public Collider col;

    public Rigidbody rigidbody;

    public Transform grabPoint = null;

    public float lifetime = 30;
    float currentTime = 0;
 
    public void lockPhysics(Transform newgrabPoint)
    {
        rigidbody.isKinematic = true;
        grabPoint = newgrabPoint;
        col.enabled = false;
    }
    public void letgo()
    {
        rigidbody.isKinematic = false;
        grabPoint = null;
        col.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabPoint != null) 
        {
            transform.position = grabPoint.position;
            transform.rotation = grabPoint.rotation;
            
        }

        currentTime = currentTime + Time.deltaTime;
        if (currentTime > lifetime)
        {
            Destroy(gameObject);
        }

    }
    
}
