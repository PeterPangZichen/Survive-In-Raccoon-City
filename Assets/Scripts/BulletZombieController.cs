using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletZombieController : MonoBehaviour
{
    public float speed = 5f;
    private int damage = 10;
    public Rigidbody2D bulletRigidBody;
    private GameObject Zombie;

    private bool playerfacedright = true;
    private int CurrentWeapon;
    private int cnt = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        Zombie = GameObject.Find("ZombieBoss");
        playerfacedright = Zombie.GetComponent<ZombieController>().GetfaceRightState();
        CurrentWeapon = 3;
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
            return 5;
        }
        if(CurrentWeapon == 2){
            return 12;
        }
        if(CurrentWeapon == 3){
            return 5;
        }
        if(CurrentWeapon == 4){
            return 20;
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
        PlayerController playerController = other.GetComponent<PlayerController>();
        if(playerController!=null){
            playerController.takeCollisionDamage(getDamageByWeapon());
        }
    }

}
