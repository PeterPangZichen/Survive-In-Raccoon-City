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


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        playerfacedright = Player.GetComponent<PlayerController>().GetfaceRightState();
        if( playerfacedright ) bulletRigidBody.velocity = transform.right * speed;
        else bulletRigidBody.velocity = transform.right * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        ZombieController zombieController = other.GetComponent<ZombieController>();
        if(zombieController!=null){
            zombieController.takeDamage(damage);
            Destroy(gameObject);
        }
    }

}
