using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerBody;

    private float horizontal;
    private float vertical;

    private bool faceRightState = true;
    private int CurrentWeapon;
    // 1 for deagle 2 for nova 3 for uzi 4 for AWP 5 for RPG
    public SpriteRenderer weaponSpriteRenderer;
    public Sprite deagleSprite;
    public Sprite novaSprite;
    public Sprite uziSprite;
    public Sprite AWPSprite;
    public Sprite RPGSprite;

    public float runSpeed = 10.0f;
    public int health = 100;
    public int fullhealth = 100;
    public Transform HPbar;
    public Slider PlayerHpBar;
    public GameObject HpBarObject;
    public int level = 5;
    // public Text hpText;
    // public Text dayText;
    // public Text weaponText;
    // private string weaponNameString = "Deagle";
    // private int dayCount = 1;
    
    public bool GetfaceRightState(){
        return faceRightState;
    }

    private GameObject WeaponObject;
    private GameObject FirePointObject;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerBody = GetComponent<Rigidbody2D>();   
        WeaponObject = gameObject.transform.GetChild(1).gameObject;     
        FirePointObject = gameObject.transform.GetChild(0).gameObject;    
        CurrentWeapon = 1;

        // dayText.text = "Day " + dayCount.ToString();
        // hpText.text = "HP " + health.ToString();
        // weaponText.text = "Weapon " + weaponNameString;
    }

    public void ChangeCurrentWeapon(int weapon){
        // 1 for deagle 2 for nova 3 for uzi 4 for AWP 5 for RPG
        if(CurrentWeapon==weapon) return;
        CurrentWeapon = weapon;
        // todo: change the fire point of each weapon;
        if(CurrentWeapon == 1){
            weaponSpriteRenderer.sprite = deagleSprite;
            // weaponNameString = "Deagle";
        }
        if(CurrentWeapon == 2){
            weaponSpriteRenderer.sprite = novaSprite;
            // weaponNameString = "NOVA";
        }
        if(CurrentWeapon == 3){
            weaponSpriteRenderer.sprite = uziSprite;
            // weaponNameString = "UZI";
        }
        if(CurrentWeapon == 4){
            weaponSpriteRenderer.sprite = AWPSprite;
            // weaponNameString = "AWP";
        }
        if(CurrentWeapon == 5){
            weaponSpriteRenderer.sprite = RPGSprite;
            // weaponNameString = "RPG";
        }
        // weaponText.text = weaponNameString;
        GetPositionForWeapon();
        WeaponObject.transform.localScale = WeaponScale;
        WeaponObject.transform.localPosition = WeaponPosition;
        FirePointObject.transform.localPosition = FirePointPosition;
        
    }

    public int GetCurrentWeapon(){
        return CurrentWeapon;
    }

    private Vector3 WeaponPosition = new Vector3(0f,0f,0f);
    private Vector3 FirePointPosition = new Vector3(0f,0f,0f);
    private Vector3 WeaponScale = new Vector3(0f,0f,0f);

    void GetPositionForWeapon(){
        // 1 for deagle 2 for nova 3 for uzi 4 for AWP 5 for RPG
        int FaceRight = 1;
        if(!faceRightState) FaceRight = -1;
        if(CurrentWeapon == 1){
            WeaponPosition = new Vector3(FaceRight*0.68f,0.6f,0f);
            FirePointPosition = new Vector3(FaceRight*1.15f,0.71f,0f);
            WeaponScale = new Vector3(FaceRight*0.158f,0.158f,1f);
            // scale 0.158 0.158
        }
        if(CurrentWeapon == 2){
            WeaponPosition = new Vector3(FaceRight*0.64f,0.69f,0f);
            FirePointPosition = new Vector3(FaceRight*1.65f,0.83f,0f);
            WeaponScale = new Vector3(FaceRight*0.194f,0.191f,1f);
            // scale 0.194 0.191
        }
        if(CurrentWeapon == 3){
            WeaponPosition = new Vector3(FaceRight*0.45f,0.69f,0f);
            FirePointPosition = new Vector3(FaceRight*1.01f,0.8f,0f);
            WeaponScale = new Vector3(FaceRight*0.156f,0.188f,1f);
            // scale 0.156 0.188
        }
        if(CurrentWeapon == 4){
            WeaponPosition = new Vector3(FaceRight*0.88f,0.71f,0f);
            FirePointPosition = new Vector3(FaceRight*1.58f,0.78f,0f);
            WeaponScale = new Vector3(FaceRight*0.33f,0.25f,1f);
            // scale 0.33 0.25
        }
        if(CurrentWeapon == 5){
            WeaponPosition = new Vector3(FaceRight*0f,0.79f,0f);
            FirePointPosition = new Vector3(FaceRight*1.58f,0.83f,0f);
            WeaponScale = new Vector3(FaceRight*0.47f,0.54f,1f);
            // scale 0.47 0.54
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("a") && faceRightState){
            faceRightState = false;
            playerSprite.flipX = true;
            // flip the weapon also!
            Vector3 scale = WeaponObject.transform.localScale;
            scale.x *= -1;
            WeaponObject.transform.localScale = scale;
            Vector3 scale2 = FirePointObject.transform.localScale;
            scale2.x *= -1;
            FirePointObject.transform.localScale = scale;
            GetPositionForWeapon();
            WeaponObject.transform.localPosition = WeaponPosition;
            FirePointObject.transform.localPosition = FirePointPosition;
        }

        if (Input.GetKeyDown("d") && !faceRightState){
            faceRightState = true;
            playerSprite.flipX = false;
            // flip the weapon
            Vector3 scale = WeaponObject.transform.localScale;
            scale.x *= -1;
            WeaponObject.transform.localScale = scale;
            Vector3 scale2 = FirePointObject.transform.localScale;
            scale2.x *= -1;
            FirePointObject.transform.localScale = scale2;
            GetPositionForWeapon();
            WeaponObject.transform.localPosition = WeaponPosition;
            FirePointObject.transform.localPosition = FirePointPosition;
        }
        // to test gun switching only:
        if (Input.GetKeyDown("p")){
            Debug.Log("Keydown P");
            Debug.Log(CurrentWeapon);
            ChangeCurrentWeapon((CurrentWeapon%level)+1);
        }

        // HP bar follow the player
        HPbar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2f);
        
    }

    private void FixedUpdate()
    {
        playerBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);   
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Zombie")) {
            takeCollisionDamage(10);
        }
    }

    public void takeCollisionDamage(int damage){
        health -= damage;
        // hpText.text = "HP " + health.ToString();
        float hpbar = (float)health/(float)fullhealth;
        PlayerHpBar.value = hpbar;
        if(health<=0){
            // Destroy(gameObject);
            // Destroy(HpBarObject);
            //Time.timeScale = 0; // pause the game
            // Change to Gameover scene
            SceneManager.LoadScene("GameOverScene");
        }
    }
}