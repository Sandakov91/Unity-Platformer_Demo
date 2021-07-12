using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D bulletRigidbody;
    protected Collider2D bulletCollider;
    protected Vector2 direction;
    protected int power;
    protected float speed;
    protected float lifeTime;
    public void SetValues(Vector2 _direction, int _power, float _speed, float _lifeTime)
    {
        direction = _direction;
        power = _power;
        speed = _speed;
        lifeTime = _lifeTime;
    }
}
