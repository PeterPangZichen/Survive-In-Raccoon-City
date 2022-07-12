using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Movement
    private float originalX;
    // private float maxOffset = 5.0f;
    // private float enemyPatroltime = 5.0f;
    // private int moveRight = -1;
    private Vector2 velocity;

    // Damage
    public int health = 20;
    public int fullhealth = 20;
    public float MAX_X_SPEED = 0.4f;
    public float MAX_Y_SPEED = 0.2f;
    public float Attack_range_x = 0.01f;
    public float Attack_range_y = 0.01f;
    public GameObject target;
    public Transform HPbar;
    public Slider ZombieHpBar;
    public GameObject HpBarObject;
    Animator animator;

    private Rigidbody2D enemyBody;
    private bool isFacingRight = true;

    void Flip()    
      {
          isFacingRight = !isFacingRight;
  
          Vector3 theScale = transform.localScale;
          theScale.x *= -1;
          transform.localScale = theScale;
  
          // Flip collider over the x-axis
          // center.x = -center.x;
      }
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    
    void ComputeVelocity(){
        velocity = new Vector2(target.transform.position.x - enemyBody.position.x, target.transform.position.y - (enemyBody.position.y-1f));
        // Speed Control
        float distance = Mathf.Sqrt(velocity.x*velocity.x+velocity.y*velocity.y);
        animator.SetFloat("Distance", distance);
        if(velocity.x>MAX_X_SPEED) velocity.x=MAX_X_SPEED;
        else if(velocity.x<-MAX_X_SPEED) velocity.x=-MAX_X_SPEED;
        if(velocity.y>MAX_Y_SPEED) velocity.y=MAX_Y_SPEED;
        else if(velocity.y<-MAX_Y_SPEED) velocity.y=-MAX_Y_SPEED;
        if(distance<2){
            velocity.x = 0f;
            velocity.y = 0f;
        }
    }

    void MoveZombie(){
        // flip the zombie
        if(velocity.x < 0f && isFacingRight == true) Flip();
        else if(velocity.x > 0f && isFacingRight == false) Flip();
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        // if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        // {
        //     MoveZombie();
        // }
        // else{
        //     // change direction
        //     moveRight *= -1;
        //     ComputeVelocity();
        //     MoveZombie();
        // }
        ComputeVelocity();
        MoveZombie();
        // HP bar follow the zombie
        HPbar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1.2f);
    }

    public void takeDamage(int damage){
        health -= damage;
        float hpbar = (float)health/(float)fullhealth;
        ZombieHpBar.value = hpbar;
        if(health<=0){
            Destroy(gameObject);
            Destroy(HpBarObject);
        }
    }
}
