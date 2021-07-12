using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    [SerializeField] private EnemyShootingPoint shootingPoint;
    private Player player;
    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }
    private void FixedUpdate()
    {
        if (!player)
        {
            Patrol();
        }
        else if (player)
        {
            enemyRigidbody.velocity = Vector2.zero;
        }
        ApplyAnimation();
    }
    private void Update()
    {
        ApplyHealth();
    }

    public override void ActivateEnemy(Player _player)
    {
        player = _player;
        shootingPoint.SetTarget(player);
        enemyAnimator.SetBool("IsShooting", true);
    }
}
