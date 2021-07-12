using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float enemySpeed;
    [SerializeField] private HealthBar hpBar;
    [SerializeField] private Transform borderLeft;
    [SerializeField] private Transform borderRight;

    protected Rigidbody2D enemyRigidbody;
    protected Animator enemyAnimator;
    protected Vector2 direction = Vector2.left;
    public int HP => hp;
    public void ApplyDamage(int damage) 
    {
        hp -= damage;
        hpBar.RefreshView();
    }

    protected void Patrol()
    {
        if(transform.position.x <= borderLeft.position.x || transform.position.x >= borderRight.position.x)
        {
            direction = -direction;
        }
        enemyRigidbody.velocity = direction * enemySpeed * Time.deltaTime + new Vector2(0, enemyRigidbody.velocity.y);
    }
    protected void ApplyAnimation() 
    {
        if (direction == Vector2.right)
        {
            enemyAnimator.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (direction == Vector2.left)
        {
            enemyAnimator.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    protected void ApplyHealth()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected void ActivateHPBar()
    {
        hpBar.gameObject.SetActive(true);
    }
    protected void ChasePlayer(Player player)
    {
        Vector2 target = (player.transform.position - transform.position).normalized;
        if (target.x > 0)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
        enemyRigidbody.velocity = target * enemySpeed * Time.deltaTime;
    }
    public abstract void ActivateEnemy(Player _player);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.ApplyDamage(1);
        }
    }
}
