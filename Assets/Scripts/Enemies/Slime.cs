using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }
    private void FixedUpdate()
    {
        Patrol();
        ApplyAnimation();
    }
    private void Update()
    {
        ApplyHealth();
    }

    public override void ActivateEnemy(Player _player)
    {

    }
}
