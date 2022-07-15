using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerBody;

    private float horizontal;
    private float vertical;

    private bool faceRightState = true;
    private int CurrentWeapon;
    // 1 for deagle
    // 2 for nova
    // 3 for uzi
    // 4 for AWP
    // 5 for RPG
    public SpriteRenderer weaponSpriteRenderer;
    public Sprite deagleSprite;
    public Sprite novaSprite;
    public Sprite uziSprite;
    public Sprite AWPSprite;
    public Sprite RPGSprite;

    public float runSpeed = 10.0f;
    public int HP = 100;
    
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
    }

    public void ChangeCurrentWeapon(int weapon){
        if(CurrentWeapon==weapon) return;
        CurrentWeapon = weapon;
        // todo: change the fire point of each weapon;
        if(CurrentWeapon == 1){
            weaponSpriteRenderer.sprite = deagleSprite;
            return;
        }
        if(CurrentWeapon == 2){
            weaponSpriteRenderer.sprite = novaSprite;
            return;
        }
        if(CurrentWeapon == 3){
            weaponSpriteRenderer.sprite = uziSprite;
            return;
        }
        if(CurrentWeapon == 4){
            weaponSpriteRenderer.sprite = AWPSprite;
            return;
        }
        if(CurrentWeapon == 5){
            weaponSpriteRenderer.sprite = RPGSprite;
            return;
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
            WeaponObject.transform.localPosition = new Vector3(-0.68f,0.6f,0f);
            FirePointObject.transform.localPosition = new Vector3(-1.05f,0.73f,0f);
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
            FirePointObject.transform.localScale = scale;
            WeaponObject.transform.localPosition = new Vector3(0.68f,0.6f,0f);
            FirePointObject.transform.localPosition = new Vector3(1.05f,0.73f,0f);
        }
        // to test gun switching only:
        if (Input.GetKeyDown("p")){
            Debug.Log("Keydown P");
            Debug.Log(CurrentWeapon);
            ChangeCurrentWeapon((CurrentWeapon%5)+1);
        }
        
    }

    private void FixedUpdate()
    {
        playerBody.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);   
    }
}
