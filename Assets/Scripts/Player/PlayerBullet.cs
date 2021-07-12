using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        bulletRigidbody.velocity = direction * speed;
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.ApplyDamage(power);
        }
        Destroy(gameObject);
    }

}
