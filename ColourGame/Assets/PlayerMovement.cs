using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    int wholeNumber = 16;
    float decimalNumber = 4.54f;
    string text = "words";
    bool boolean = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * 7f, rb.velocity.y);



        if (Input.GetKey("space"))
        { 
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 7, 0);
        }
    }
    
}
