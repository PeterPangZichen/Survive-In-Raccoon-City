using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageChangeController : MonoBehaviour
{
    private float ftime;
    private float sleeptime = 5f;
    private int index = 0;
    private int reverseIndex;
    public GameObject sceneText;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public bool start = true;
    public bool end = false;
    public bool firstEndScene = false;

    // Start is called before the first frame update
    void Start()
    {
        reverseIndex = spriteArray.Length;
        sceneText.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if(start){
            ftime += Time.deltaTime;
            if(ftime >= 0.12f)
            {
                index++;
                spriteRenderer.sprite = spriteArray[index];
                ftime = 0f;
                if(index == spriteArray.Length-1){
                    start = false;
                    sceneText.SetActive(true);
                }
            }
        }else if(end&&firstEndScene){
            ftime += Time.deltaTime;
            if(ftime >= 0.12f)
            {
                index--;
                spriteRenderer.sprite = spriteArray[index];
                ftime = 0f;
                if(index == 0){
                    end = false;
                    SceneManager.LoadScene("EndScene2");
                }
            }
        }else if(!firstEndScene){
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene("IntroScene");
            }
        }else{
            sleeptime -= Time.deltaTime;
            if(sleeptime <= 0){
                end = true;
                sleeptime = 10000f;
            }
        }
   }
}
