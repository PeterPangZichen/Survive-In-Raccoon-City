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
        if(CurrentWeapon == 1){
            if(Input.GetKeyDown("j")){
            ShootDeagle();
            }
        }
        if(CurrentWeapon == 2){
            if(Input.GetKeyDown("j")){
            ShootNova();
            }
        }
        if(CurrentWeapon == 3){
            if(Input.GetKeyDown("j")){
            ShootUZI();
            }
        }
        if(CurrentWeapon == 4){
            if(Input.GetKeyDown("j")){
            ShootAWP();
            }
        }
        if(CurrentWeapon == 5){
            if(Input.GetKeyDown("j")){
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
