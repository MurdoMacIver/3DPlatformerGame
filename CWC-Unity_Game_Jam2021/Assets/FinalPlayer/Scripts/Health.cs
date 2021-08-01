using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    public void ReduceHealth()
    {
        health--;

        if (health <= 0)
            Destroy(this.gameObject);
    }
}
