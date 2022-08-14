using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseController : MonoBehaviour
{
    public int health = 100;
    public int fullhealth = 100;
    public Transform HPbar;
    public Slider BaseHpBar;
    public GameObject HpBarObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPbar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1.2f);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Zombie")) {
            takeCollisionDamage(10);
        }
    }

    public void takeCollisionDamage(int damage){
        health -= damage;
        float hpbar = (float)health/(float)fullhealth;
        BaseHpBar.value = hpbar;
        if(health<=0){
            // Destroy(gameObject);
            // Destroy(HpBarObject);
            // Change to Gameover scene
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
