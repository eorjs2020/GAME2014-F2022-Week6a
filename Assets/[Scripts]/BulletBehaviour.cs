﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public struct ScreenBounds
{
    public Boundary horizontal;
    public Boundary vertical;
}


public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Properties")]
    public float speed;
    public BulletDirection direction;
    public Vector3 velocity;
    public ScreenBounds bounds;
    public BulletManager bulletManager;
    public BulletType bulletType;

    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        SetDirection(direction);
    }

    private void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    public void CheckBounds()
    {
        if ((transform.position.x > bounds.horizontal.max) || 
            (transform.position.x < bounds.horizontal.min) ||
            (transform.position.y > bounds.vertical.max) ||
            (transform.position.y < bounds.vertical.min))
        {            
            bulletManager.ReturnBullet(this.gameObject, bulletType);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((bulletType == BulletType.PLAYER) || 
            (bulletType == BulletType.ENEMY & collision.gameObject.CompareTag("Player")))
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
        }
        
    }

    public void SetDirection(BulletDirection dir)
    {
        direction = dir;
        switch (dir)
        {
            case BulletDirection.UP:                
                velocity = Vector3.up * speed;
                break;
            case BulletDirection.DOWN:
                velocity = Vector3.down * speed;
                break;
            case BulletDirection.LEFT:
                velocity = Vector3.left * speed;
                break;
            case BulletDirection.RIGHT:
                velocity = Vector3.right * speed;
                break;
        }
    }
}