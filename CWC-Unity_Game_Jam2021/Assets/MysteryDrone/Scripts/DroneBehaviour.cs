using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed = 1.5f;

    PlayerInput player;

    [SerializeField]
    Texture[] textures;

    [SerializeField]
    Renderer render;

    [SerializeField]
    Animator droneAnimator;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3);
        player = FindObjectOfType<PlayerInput>();
        SetTexture();
    }

    // Update is called once per frame
    private void Update()
    {
        if (player)
        {

            Vector3 relativePos = player.transform.position - transform.position;

            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);

            transform.rotation = rotation;

            if (Vector3.Distance(transform.position, player.transform.position) < 15f && player.transform.position.y <= transform.position.y)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
                droneAnimator.SetBool("isWalking", true);
            }
            else
            {
                droneAnimator.SetBool("isWalking", false);
            }
        }
    }

    /*public void Die()
    {
        droneAnimator.SetTrigger("die");
    }

    public void TakeDamage()
    {
        droneAnimator.SetTrigger("takeDamage");
    }

    public void Taunt()
    {
        droneAnimator.SetTrigger("taunt");
    }

    public void Attack()
    {
        droneAnimator.SetTrigger("attack");
    }*/

    public void SetTexture()
    {
        render.sharedMaterial.SetTexture("_MainTex", textures[Random.Range(0, textures.Length)]);
    }
}