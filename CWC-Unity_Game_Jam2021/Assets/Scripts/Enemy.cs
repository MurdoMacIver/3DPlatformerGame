using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    GameObject barell;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        Instantiate(barell, transform.position, transform.rotation * Quaternion.Euler(90f, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector3(speed, 0, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        speed *= -1;
    }
}
