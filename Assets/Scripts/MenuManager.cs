using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int NumOfLevels;
    public Sprite[] Levels;

    public MenuData MenuScript;
    public GameObject LockedCover;
    public SpriteRenderer LevelSprite;

    private int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        LockedCover.SetActive(!MenuScript.levelPass[currentLevel-1]);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("d")){
            if(currentLevel<NumOfLevels){
                currentLevel++;
                LevelSprite.sprite = Levels[currentLevel-1];
                LockedCover.SetActive(!MenuScript.levelPass[currentLevel-1]);
            }
        };
        if(Input.GetKeyDown("a")){
            if(currentLevel>1){
                currentLevel--;
                LevelSprite.sprite = Levels[currentLevel-1];
                LockedCover.SetActive(!MenuScript.levelPass[currentLevel-1]);
            }
        };
        if(Input.GetKeyDown("space")){
            if(MenuScript.levelPass[currentLevel-1]){
                MenuScript.difficulty = currentLevel-1;
                SceneManager.LoadScene("MainScene");
            }
        };
    }
}
