using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Properties")]
    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;
    public float verticalSpeed = 6;
    public bool usingMoblieInput = false;
    public ScoreManager scoreManager;

    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    public Transform bulletParent;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        transform.position = new Vector2(0, verticalPosition);

        
        usingMoblieInput = Application.platform == RuntimePlatform.Android ||
                           Application.platform == RuntimePlatform.IPhonePlayer;
        /*if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
        {
            usingMoblieInput = false;
        }
        else
        {
            usingMoblieInput = true;
        }*/
        scoreManager = FindObjectOfType<ScoreManager>();
        InvokeRepeating("FireBullets", 0.0f, fireRate);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(usingMoblieInput)
            MobileInput();
        else
            ConventionalInput();
        Move();

        if(Input.GetKeyDown(KeyCode.K))
        {
            scoreManager.AddPoints(10);
        }
    }
    
    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = cam.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * 10);
        }
    }

    public void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        transform.position += new Vector3(x, 0, 0);
    }
    void Move()
    {             
        float clampPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundary.min, boundary.max) , verticalPosition);
    }

    void FireBullets()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity, bulletParent);
    }
 
}
