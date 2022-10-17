using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    [Header("Bullet Properties")]
    
    public int playerBulletCount = 0;
    public int playerActiveBullets = 0;
    [Range(0, 50)]
    public int playerBulletNumber = 50;

    public int enemyBulletCount = 0;
    public int enemyActiveBullets = 0;
    [Range(0, 50)]
    public int enemeyBulletNumber = 50;

    public BulletFactory factory;

    private Queue<GameObject> playerBulletPool;
    private Queue<GameObject> enemyBulletPool;
    // Start is called before the first frame update
    void Start()
    {
        playerBulletPool = new Queue<GameObject>(); //create an empty queue container
        enemyBulletPool = new Queue<GameObject>();
        factory = GameObject.FindObjectOfType<BulletFactory>();
        BuildBulletPool();
        
    }

    void BuildBulletPool()
    {
        for(int i = 0; i < playerBulletNumber; i++)
        {
            playerBulletPool.Enqueue(factory.createBullet(BulletType.PLAYER));
        }

        for (int i = 0; i < enemeyBulletNumber; i++)
        {
            enemyBulletPool.Enqueue(factory.createBullet(BulletType.ENEMY));
        }

        playerBulletCount = playerBulletPool.Count;
        enemyBulletCount = enemyBulletPool.Count;
    }

    public GameObject GetBullet(Vector2 position, BulletType type)
    {
        

        GameObject bullet = null;
        
        switch(type)
        {
            case BulletType.PLAYER:
                {
                    if (playerBulletPool.Count < 1)
                    {
                        playerBulletPool.Enqueue(factory.createBullet(BulletType.PLAYER));
                    }
                    bullet = playerBulletPool.Dequeue();
                    playerBulletCount = playerBulletPool.Count;
                    playerActiveBullets++;
                }
                break;
            case BulletType.ENEMY:
                {
                    if (enemyBulletPool.Count < 1)
                    {
                        enemyBulletPool.Enqueue(factory.createBullet(BulletType.ENEMY));
                    }
                    bullet = enemyBulletPool.Dequeue();
                    enemyBulletCount = enemyBulletPool.Count;
                    enemyActiveBullets++;
                }
                break;
        }        
           
        bullet.SetActive(true);
        bullet.transform.position = position;        

        //stats
        

        return bullet;
    }
    
    public void ReturnBullet(GameObject bullet, BulletType type)
    {
        bullet.SetActive(false);

        switch(type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(bullet);
                enemyBulletCount = enemyBulletPool.Count;
                enemyActiveBullets--;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(bullet);
                playerBulletCount = playerBulletPool.Count;
                playerActiveBullets--;
                break;
        }
        
    }
}
