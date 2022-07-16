using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
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
        if( playerfacedright ) bulletRigidBody.velocity = transform.right * speed;
        else bulletRigidBody.velocity = transform.right * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        cnt += 1;
        if(cnt > 60 && CurrentWeapon == 2){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        ZombieController zombieController = other.GetComponent<ZombieController>();
        if(zombieController!=null){
            zombieController.takeDamage(damage);
            Destroy(gameObject);
        }
    }

}
