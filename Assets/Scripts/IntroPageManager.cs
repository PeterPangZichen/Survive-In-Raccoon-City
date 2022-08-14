using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPageManager : MonoBehaviour
{
    public GameObject tutorial;
    private bool status = true;

    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p")){
            tutorial.SetActive(status);
            status = !status;
        }
        if(Input.GetKeyDown("space")){
            SceneManager.LoadScene("StartScene1");
        }
        
    }
}
