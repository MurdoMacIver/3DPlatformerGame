using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    [SerializeField]
    int health = 1;

    [SerializeField]
    GameObject particleEffectStars;

    [SerializeField]
    GameObject particleEffectExplosion;

    [SerializeField]
    GameObject destroyBox;

    [SerializeField]
    GameObject[] spawns;

    Vector3 newPos;


    public void ReduceHealth()
    {
        health--;

        if (health <= 0)
        {
            GameObject newDestroyBox = Instantiate(destroyBox, transform.position, Quaternion.identity);
            Destroy(newDestroyBox, 3f);
            GameObject newParticleEffectStars = Instantiate(particleEffectStars, transform.position, Quaternion.identity);
            Destroy(newParticleEffectStars, 1.5f);
            GameObject newParticleEffectExplosion = Instantiate(particleEffectExplosion, transform.position, Quaternion.identity);
            Destroy(newParticleEffectExplosion, 1.5f);

            int spawnindex = Random.Range(0, spawns.Length);

            if (spawnindex == 1)
            {
                newPos = new Vector3(0, 0, -2);
            }
            else
            {
                newPos = Vector3.zero;
            }

            GameObject newSpawn = Instantiate(spawns[spawnindex], transform.position + newPos, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}