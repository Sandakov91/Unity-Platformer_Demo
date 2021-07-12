using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPoint : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;
    [SerializeField] private float reloadTime;
    [SerializeField] private int bulletPower;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Collider2D ignoredCollider;

    protected bool canShoot = true;
    protected float reloadRate;
    protected void Shoot()
    {
        canShoot = false;
        Vector2 bulletDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        bulletDirection = bulletDirection.normalized;
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.SetValues(bulletDirection, bulletPower, bulletSpeed, bulletLifeTime);
        Physics2D.IgnoreCollision(bullet.gameObject.GetComponent<Collider2D>(), ignoredCollider);
        bullet.gameObject.transform.SetParent(null);
    }
    protected void ShootOnTarget(Player target)
    {
        canShoot = false;
        Vector2 bulletDirection = target.transform.position - transform.position;
        bulletDirection = bulletDirection.normalized;
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.SetValues(bulletDirection, bulletPower, bulletSpeed, bulletLifeTime);
        Physics2D.IgnoreCollision(bullet.gameObject.GetComponent<Collider2D>(), ignoredCollider);
        bullet.gameObject.transform.SetParent(null);
    }
    protected void Reload()
    {
        if (!canShoot)
        {
            reloadRate += Time.deltaTime;
            if (reloadRate >= reloadTime)
            {
                reloadRate = 0;
                canShoot = true;
            }
        }
    }
}
