using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        bulletRigidbody.velocity = direction * speed;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.ApplyDamage(power);
        }
        Destroy(gameObject);
    }
}
