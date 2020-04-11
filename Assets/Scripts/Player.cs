using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Vector2 movement;
    public float speed = 20f;
    Rigidbody2D rb;

    private Vector2 ScreenBounds;
    float objectWidth;
    float objectHeight;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
    }

    void FixedUpdate()
    {
        
        
            rb.velocity = movement * speed * Time.deltaTime;
        

    }

    void LateUpdate()
    {
        Vector2 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -ScreenBounds.x + objectWidth, ScreenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -ScreenBounds.y + objectHeight, ScreenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
