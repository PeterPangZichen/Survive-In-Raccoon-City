using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponImageManager : MonoBehaviour
{
    public MenuData menudata;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = spriteArray[menudata.difficulty-1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            SceneManager.LoadScene("MainScene");
        }
    }
}
