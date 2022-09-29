using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, verticalPosition);
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
        //CheckBound();
    }
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;  


        transform.position += new Vector3(x, 0, 0);        
        float clampPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundary.min, boundary.max) , verticalPosition);
    }
  /*  void CheckBound()
    {
        if (transform.position.x > boundary.max)
        {
            transform.position = new Vector2(boundary.max, verticalPosition);
        }
        if (transform.position.x < boundary.min)
        {
            transform.position = new Vector2(boundary.min, verticalPosition);
        }
        
    }*/
}
