using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZombieBossController : MonoBehaviour
{
    // private SpriteRenderer zombieSprite;

    // Movement
    private float originalX;
    // private float maxOffset = 5.0f;
    // private float enemyPatroltime = 5.0f;
    // private int moveRight = -1;
    private Vector2 velocity;
    private bool isBouncing;
    private bool guideZombie = false;

    // Damage
    public bool isboss = false;
    private int health = 1000;
    public int fullhealth = 1000;
    public float MAX_X_SPEED = 0.4f;
    public float MAX_Y_SPEED = 0.2f;
    private float Attack_range_x = 0.01f;
    private float Attack_range_y = 0.01f;
    private GameObject target;
    private GameObject prevTarget;
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
        prevTarget = baseObject;

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

        target = player;
        
        velocity = new Vector2(target.transform.position.x - enemyBody.position.x, target.transform.position.y - (enemyBody.position.y-1f));
        
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

            if (r.Next(1, 5) <= 1) {
                GameObject consumablePrefab = r.Next(1, 7) <= 3 ? milkPrefab : stimPrefab;
                Instantiate(consumablePrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            }
            
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
        if (col.CompareTag("HouseBottom")) {
            Debug.Log("Zombie entering house bottom");
            guideZombie = true;
            GameObject colObject = col.transform.parent.gameObject;
            target = colObject.transform.Find("BottomRight").gameObject;
            // Debug.Log("Target Name: " + target.name);
        }
        if (col.CompareTag("HouseRight")) {
            Debug.Log("Zombie entering house right");
            guideZombie = true;
            GameObject colObject = col.transform.parent.gameObject;
            target = colObject.transform.Find("TopRight").gameObject;

        }
        if (col.CompareTag("HouseLeft")) {
            Debug.Log("Zombie entering house left");
            guideZombie = true;
            GameObject colObject = col.transform.parent.gameObject;
            target = colObject.transform.Find("TopLeft").gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Reset pushing state to false
        if (col.CompareTag("HouseBottom")) {
            Debug.Log("Zombie leaves house bottom");
            guideZombie = false;
        }
        if (col.CompareTag("HouseRight")) {
            Debug.Log("Zombie leaves house right");
            guideZombie = false;
        }
        if (col.CompareTag("HouseLeft")) {
            Debug.Log("Zombie leaves house left");
            guideZombie = false;
        }
    }

    void StopBounce()
    {
        isBouncing = false;
    }

}