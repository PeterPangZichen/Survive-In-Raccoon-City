using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // private SpriteRenderer zombieSprite;

    // Movement
    private float originalX;
    // private float maxOffset = 5.0f;
    // private float enemyPatroltime = 5.0f;
    // private int moveRight = -1;
    private Vector2 velocity;
    private bool isBouncing;

    private bool pushRight = false;
    private bool pushUp = false;
    private bool guideZombie = false;

    // Damage
    private int health = 40;
    private int fullhealth = 40;
    private float MAX_X_SPEED = 0.4f;
    private float MAX_Y_SPEED = 0.2f;
    private float Attack_range_x = 0.01f;
    private float Attack_range_y = 0.01f;
    private GameObject target;
    private GameObject player;
    private GameObject baseObject;
    private float distanceToPlayer;
    // public Transform HPbar;
    // public Slider ZombieHpBar;
    // public GameObject HpBarObject;
    Animator animator;

    private Rigidbody2D enemyBody;
    private bool isFacingRight = true;

    public GameObject milkPrefab;
    public GameObject stimPrefab;

    public AudioSource zombienoise;
    // public AudioClip noise;
    //public bool testing;

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
        // zombieSprite = GetComponent<SpriteRenderer>();
        enemyBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        zombienoise = GetComponent<AudioSource>();
        //zombienoise.PlayOneShot(noice,0.5f);
        // get the starting position
        originalX = transform.position.x;
        player = GameObject.Find("Player");
        baseObject = GameObject.Find("Base");
        // define target as the base
        target = baseObject;

        //testing = true;
        
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        ComputeVelocity();
    }
    
    void ComputeVelocity(){
        distanceToPlayer = Vector2.Distance (transform.position, player.transform.position);
        // Debug.Log("Distance with player: " + distanceToPlayer);
        if (!guideZombie) {
            // If guideZombie==true, targetting the corner of the house
            // Else, set target to player or base
            if (distanceToPlayer <= 5) {
                target = player;
            } else {
                target = baseObject;
            }
        } 

        if (pushRight) {
            velocity = new Vector2(MAX_X_SPEED, MAX_Y_SPEED);
        } else if (pushUp) {
            velocity = new Vector2(0, MAX_Y_SPEED);
        } else {
            velocity = new Vector2(target.transform.position.x - enemyBody.position.x, target.transform.position.y - (enemyBody.position.y-1f));
        }

        // velocity = new Vector2(target.transform.position.x - enemyBody.position.x, target.transform.position.y - (enemyBody.position.y-1f));
        
        // Speed Control
        float distance = Mathf.Sqrt(velocity.x*velocity.x+velocity.y*velocity.y);
        animator.SetFloat("Distance", distance);

        // Limit Speed
        if(velocity.x>MAX_X_SPEED) velocity.x=MAX_X_SPEED;
        else if(velocity.x<-MAX_X_SPEED) velocity.x=-MAX_X_SPEED;
        if(velocity.y>MAX_Y_SPEED) velocity.y=MAX_Y_SPEED;
        else if(velocity.y<-MAX_Y_SPEED) velocity.y=-MAX_Y_SPEED;

        // Stops the zombie when too close???
        // if(distance<2){
        //     velocity.x = 0f;
        //     velocity.y = 0f;
        // }
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
        distanceToPlayer = Vector2.Distance (transform.position, player.transform.position);
        if (distanceToPlayer <= 5) {
            zombienoise.Play();
        } 

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
        // Move zombie if no collision with other objects
        if (!isBouncing) {
            MoveZombie();
        }
        // HP bar follow the zombie
        // HPbar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1.2f);
    }

    public void takeDamage(int damage){
        animator.SetTrigger("isHurt");
        health -= damage;
        // float hpbar = (float)health/(float)fullhealth;
        // ZombieHpBar.value = hpbar;
        if(health<=0){
            Destroy(gameObject);
            // Destroy(HpBarObject);
            var r = new System.Random();

            GameObject consumablePrefab = r.Next(1, 7) <= 3 ? milkPrefab : stimPrefab;
            Instantiate(consumablePrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        float bounce = 6f;
        if (col.gameObject.CompareTag("Base") || col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Obstacle")) {
             //amount of bouncing force to apply
            enemyBody.AddForce(col.contacts[0].normal * bounce);
            isBouncing = true;
            Invoke("StopBounce", 0.3f);
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        // Vector2 bottomRightCorner = new Vector2(col.transform.position.x - (col.spriteWidth / 2), col.transform.position.y - (col.spriteHeight / 2));
        // Vector2 topRightCorner = new Vector2(col.transform.position.x - (col.spriteWidth / 2), col.transform.position.y + (col.spriteHeight / 2));
        // Debug.Log("GameObject2 collided with " + col.name);
        if (col.CompareTag("HouseBottom")) {
            Debug.Log("Zombie entering house bottom");
            pushRight = true;
            // guideZombie = true;
            // target = bottomRightCornerObject...
            // target = bottomRightCorner;
        }
        if (col.CompareTag("HouseSide")) {
            Debug.Log("Zombie entering house side");
            pushUp = true;
            // guideZombie = true;
            // target = topRightCornerObject...
            // target = topRightCorner;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Reset pushing state to false
        if (col.CompareTag("HouseBottom")) {
            Debug.Log("Zombie leaves house bottom");
            pushRight = false;
            // guideZombie = false;
            // target = 
        }
        if (col.CompareTag("HouseSide")) {
            Debug.Log("Zombie leaves house side");
            pushUp = false;
            // guideZombie = false;
            // target = 
        }
    }

    void StopBounce()
    {
        isBouncing = false;
    }

}
