using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    private Player player;
    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }
    private void FixedUpdate()
    {
        if (player)
        {
            ChasePlayer(player);
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
        ActivateHPBar();
        enemyAnimator.SetBool("IsActive", true);
    }
}
