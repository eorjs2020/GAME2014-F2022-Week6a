using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    // Bullet Prefab
    public GameObject bulletPrefab;

    // Sprite Textures
    public Sprite playerBulletSprite;
    public Sprite enemyBulletSprite;

    // Bullet Parent
    public Transform bulletParent;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        playerBulletSprite = Resources.Load<Sprite>("Sprites/Bullet");
        enemyBulletSprite = Resources.Load<Sprite>("Sprites/EnemySmallBullet");
        bulletPrefab = Resources.Load<GameObject>("Prefabs/PlayerBullet");
        bulletParent = GameObject.Find("Bullets").transform;
    }

    public GameObject createBullet(BulletType type)
    {
        GameObject bullet = null;
        switch(type)
        {
            case BulletType.PLAYER:
                bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);
                bullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.UP);
                break;
            case BulletType.ENEMY:
                bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, bulletParent);
                bullet.GetComponent<SpriteRenderer>().sprite = enemyBulletSprite;
                bullet.GetComponent<BulletBehaviour>().SetDirection(BulletDirection.DOWN);
                break;
        }

        bullet.SetActive(true);
        return bullet;
    }
}
