using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessSceneManager : MonoBehaviour
{
    public MenuData MenuScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            if(MenuScript.difficulty!=4){
                SceneManager.LoadScene("MenuScene");
            }else{
                SceneManager.LoadScene("EndScene1");
            }
        }
    }
}
