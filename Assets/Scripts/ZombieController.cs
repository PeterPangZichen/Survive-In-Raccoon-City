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
    public GameObject target;
    public Transform HPbar;
    public Slider ZombieHpBar;
    public GameObject HpBarObject;

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
        velocity = new Vector2(target.transform.position.x - enemyBody.position.x, target.transform.position.y - enemyBody.position.y);
    }

    void MoveZombie(){
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
