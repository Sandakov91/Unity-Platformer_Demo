using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    private Collider2D playerCollider;
    private Vector2 playerDirection;
    private bool hasDoubleJump;
    private Interactable interactableObject;

    public int health { get; private set; }

    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerJumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private DeathPanel deathPanel;

    private void Start()
    {
        Time.timeScale = 1;
        health = 3;
        playerHP.RefreshHPView();
        playerAnimator = GetComponentInChildren<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        ApplyMovement();
        ApplyAnimation();
        ApplyInteractions();
        if (health <= 0 || transform.position.y < -5f)
        {
            Loose();
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = playerDirection * playerSpeed * Time.deltaTime + new Vector2(0f, playerRigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PickUp") collision.GetComponent<PickUp>().AddEffect(this);
        else if (collision.tag == "Enemy") collision.GetComponent<Enemy>().ActivateEnemy(this);
        else if (collision.tag == "Interactable") interactableObject = collision.GetComponent<Interactable>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactable") interactableObject = null;
    }

    private void ApplyMovement()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            playerDirection = new Vector2(Input.GetAxis("Horizontal"), 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                playerRigidbody.velocity = Vector2.up * playerJumpForce;
            }
            else if (!IsGrounded() && hasDoubleJump)
            {
                hasDoubleJump = false;
                playerRigidbody.velocity = Vector2.up * playerJumpForce;
            }
        }
    }
    private void ApplyAnimation()
    {
        playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(playerRigidbody.velocity.x));
        playerAnimator.SetBool("IsJumping", !IsGrounded());

        if(playerRigidbody.velocity.x < 0f)
        {
            playerAnimator.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (playerRigidbody.velocity.x >= 0f)
        {
            playerAnimator.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private bool IsGrounded()
    {
        float checkDistance = 0.05f;
        RaycastHit2D hit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, checkDistance, groundLayer);
        return hit.collider != null;
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        playerHP.RefreshHPView();
    }
    private void ApplyInteractions()
    {
        if (interactableObject && Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.Interact();
        }
    }
    private void Loose() 
    {
        deathPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void AddDoubleJump()
    {
        hasDoubleJump = true;
    }

    public void AddKey()
    {
        playerInventory.AddKey();
    }

    public void Heal()
    {
        health++;
        if (health >= 3)
        {
            health = 3;
        }
        playerHP.RefreshHPView();
    }
}
