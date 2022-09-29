using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;

    public Camera cam;

    void Start()
    {
        cam = Camera.main;
        transform.position = new Vector2(0, verticalPosition);
    }
    
    // Update is called once per frame
    void Update()
    {
        MobileInput();
        //ConventionalInput();
        Move();
    }
    
    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            transform.position = cam.ScreenToWorldPoint(touch.position);
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
 
}
