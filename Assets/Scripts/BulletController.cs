using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    private int damage = 10;
    public Rigidbody2D bulletRigidBody;
    private GameObject Player;

    private bool playerfacedright = true;
    private int CurrentWeapon;
    private int cnt = 0;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerfacedright = Player.GetComponent<PlayerController>().GetfaceRightState();
        CurrentWeapon = Player.GetComponent<PlayerController>().GetCurrentWeapon();
        if( playerfacedright ){
            bulletRigidBody.velocity = transform.right * speed; 
        }
        else 
        {
            bulletRigidBody.velocity = transform.right * -speed;
            Vector3 scale2 = gameObject.transform.localScale;
            scale2.x *= -1;
            gameObject.transform.localScale = scale2;
        }
    }

    private int getDamageByWeapon(){
        if(CurrentWeapon == 1){
            return 10;
        }
        if(CurrentWeapon == 2){
            return 28;
        }
        if(CurrentWeapon == 3){
            return 10;
        }
        if(CurrentWeapon == 4){
            return 40;
        }
        if(CurrentWeapon == 5){
            return 100;
        }
        return 0;
    }
    // Update is called once per frame
    void Update()
    {
        cnt += 1;
        if(cnt > 60 && CurrentWeapon == 2){
            Destroy(gameObject);
        }
        if(cnt > 480) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        ZombieController zombieController = other.GetComponent<ZombieController>();
        if(zombieController!=null){
            zombieController.takeDamage(getDamageByWeapon());
            if(CurrentWeapon!=4) Destroy(gameObject);
            if(CurrentWeapon==5){
                //gameObject.animation.Play("explode");
                //Destroytimer();
            }
            
        }
    }

}
