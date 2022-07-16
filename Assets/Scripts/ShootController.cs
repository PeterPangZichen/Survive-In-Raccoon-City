using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject DeagleBulletPrefab;
    public GameObject NovaBulletPrefab;
    private int CurrentWeapon;
    private GameObject player;
    public GameObject UZIBulletPrefab;
    public GameObject AWPBulletPrefab;
    public GameObject RPGBulletPrefab;
    private float[] firerate = new float[] {0.2f, 0.4f, 0.1f, 1f, 3f };
    private float CurrentFirerate = 0f;
    private float LastShotTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        CurrentWeapon = player.GetComponent<PlayerController>().GetCurrentWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentWeapon = player.GetComponent<PlayerController>().GetCurrentWeapon();
        CurrentFirerate = firerate[CurrentWeapon-1];
        if(Input.GetKeyDown("j") && Time.time > LastShotTime + CurrentFirerate){
            Debug.Log(CurrentWeapon);
            LastShotTime = Time.time;
            if(CurrentWeapon == 1){ // shoot 3 per sec
                ShootDeagle();
            }
            if(CurrentWeapon == 2){ // shoot 2 per sec
                ShootNova();
            }
            if(CurrentWeapon == 3){ // shoot 6 per sec
                ShootUZI();
            }
            if(CurrentWeapon == 4){ // shoot 1 per sec
                ShootAWP();
            }
            if(CurrentWeapon == 5){ // shoot 0.33 per sec
                ShootRPG();
            }
        }
        
        
    }

    void ShootDeagle(){
        Instantiate(DeagleBulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootNova(){
        Instantiate(NovaBulletPrefab, firePoint.position, firePoint.rotation);
    }
    void ShootUZI(){
        Instantiate(UZIBulletPrefab, firePoint.position, firePoint.rotation);
    }
    void ShootAWP(){
        Instantiate(AWPBulletPrefab, firePoint.position, firePoint.rotation);
    }
    void ShootRPG(){
        Instantiate(RPGBulletPrefab, firePoint.position, firePoint.rotation);
    }
}
