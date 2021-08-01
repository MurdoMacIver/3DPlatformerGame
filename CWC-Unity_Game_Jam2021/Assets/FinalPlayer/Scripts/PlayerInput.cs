using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    int health = 3;

    [SerializeField]
    float playerSpeed = 2.0f;

    [SerializeField]
    float jumpHeight = 1.0f;

    [SerializeField]
    float gravityValue = -9.81f;

    [SerializeField]
    float turnSpeed = 5f;

    bool groundedPlayer;

    bool canDoubleJump = false;

    Vector3 playerVelocity;

    CharacterController controller;

    Animator animator;

    Transform cameraTransform;

    PlayerCanvasController playerHealthUpdater;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        playerHealthUpdater = FindObjectOfType<PlayerCanvasController>();
        cameraTransform = Camera.main.transform;
        playerHealthUpdater.UpdateHealthUI(health);
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if (!groundedPlayer)
            move.x = 0;

        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.y = 0;

        controller.Move(playerSpeed * Time.deltaTime * move);
        animator.SetFloat("move", move.magnitude);

        if (move.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        }

        if (groundedPlayer)
        {
            //animator.SetBool("runningJump", false);
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump") && move.magnitude == 0)
            {
                animator.SetBool("standingJump", true);
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            else if (Input.GetButtonDown("Jump"))
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                //animator.SetBool("runningJump", true);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                //animator.SetBool("runningJump", true);
                canDoubleJump = false;
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //if player falls off edges
        //need to grab player location

        if (cameraTransform.position.y < -50f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void SetStandingJumpAnimation()
    {
        animator.SetBool("standingJump", false);
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        DamageDealer damage = hit.transform.GetComponent<DamageDealer>();
        Health otherHealth = hit.transform.GetComponent<Health>();
        MysteryBox mysteryBox = hit.transform.GetComponent<MysteryBox>();
        HealthPotion healthPotion = hit.transform.GetComponent<HealthPotion>();

        if (otherHealth)
        {
            otherHealth.ReduceHealth();
        }

        if (damage)
        {
            health -= damage.GetDamage();
            playerHealthUpdater.UpdateHealthUI(health);

            if (health <= 0)
            {
                Destroy(this.gameObject);
                //displaying gameover screen
                SceneManager.LoadScene("GameOver");
            }
        }

        if (mysteryBox)
        {
            mysteryBox.ReduceHealth();
        }

        if (healthPotion)
        {
            if (health < 5)
            {
                health++;
            }
            
            playerHealthUpdater.UpdateHealthUI(health);
            Destroy(healthPotion.gameObject);
        }
    }
}
