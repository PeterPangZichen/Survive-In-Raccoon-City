using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerBody;

    private float horizontal;
    private float vertical;

    private bool faceRightState = true;

    public float runSpeed = 10.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerBody = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("a") && faceRightState){
            faceRightState = false;
            playerSprite.flipX = true;
        }

        if (Input.GetKeyDown("d") && !faceRightState){
            faceRightState = true;
            playerSprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        playerBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);   
    }
}
