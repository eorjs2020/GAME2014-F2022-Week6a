using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Boundary horizontalBoundary;
    public Boundary verticalBoundary;
    public Boundary horizontalSpeedRange;
    public Boundary screenBounds;
    public float horizontalSpeed;
    public float verticallSpeed;
    public SpriteRenderer spriteRenderer;
    public Color ramColor;

    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;
    public BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetEnemy();

        InvokeRepeating("FireBullets", 0.0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        var horizontalLength = horizontalBoundary.max - horizontalBoundary.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max, 
            transform.position.y - verticallSpeed * Time.deltaTime, transform.position.z);
    }

    public void CheckBounds()
    {
        if (transform.position.y < screenBounds.min)
        {
            ResetEnemy();
        }
    }

    public void ResetEnemy()
    {
        var RamXPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
        var RamYPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
        horizontalSpeed = Random.Range(1.0f, 6.0f);
        verticallSpeed = Random.Range(1.0f, 3.0f);
        transform.position = new Vector3((float)RamXPosition, (float)RamYPosition, 0.0f);
        
        List<Color> colors = new List<Color>() {Color.red, Color.yellow, Color.magenta, Color.cyan, Color.white, Color.white };
        ramColor = colors[Random.Range(1, 6)];
        spriteRenderer.material.SetColor("_Color", ramColor);
    }

    void FireBullets()
    {
        var bullet = bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.ENEMY);
    }
}
