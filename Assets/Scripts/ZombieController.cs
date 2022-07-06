using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Movement
    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 5.0f;
    private int moveRight = -1;
    private Vector2 velocity;

    // Damage
    public int health = 20;

    private Rigidbody2D enemyBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    
    void ComputeVelocity(){
        velocity = new Vector2((moveRight)*maxOffset / enemyPatroltime, 0);
    }

    void MoveZombie(){
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        {
            MoveZombie();
        }
        else{
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            MoveZombie();
        }
    }

    public void takeDamage(int damage){
        health -= damage;
        if(health<=0){
            Destroy(gameObject);
        }
    }
}
