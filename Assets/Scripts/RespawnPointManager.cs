using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointManager : MonoBehaviour
{
    public GameObject[] ZombiePrefebs;
    public MenuData MenuData;
    
    private int difficulty;
    private float timer;
    private float delayTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        difficulty = MenuData.difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= delayTime){
            timer = 0;
            int index;
            switch(difficulty){
                case 0:
                    index = Random.Range(0,2);
                    Instantiate(ZombiePrefebs[index], new Vector3(this.transform.position.x, this.transform.position.y  +  1.0f, this.transform.position.z), Quaternion.identity);
                    break;
                case 1:
                    index = Random.Range(0,3);
                    Instantiate(ZombiePrefebs[index], new Vector3(this.transform.position.x, this.transform.position.y  +  1.0f, this.transform.position.z), Quaternion.identity);
                    break;
                case 2:
                    index = Random.Range(2,5);
                    Instantiate(ZombiePrefebs[index], new Vector3(this.transform.position.x, this.transform.position.y  +  1.0f, this.transform.position.z), Quaternion.identity);
                    break;
                case 3:
                    index = Random.Range(0,6);
                    Instantiate(ZombiePrefebs[index], new Vector3(this.transform.position.x, this.transform.position.y  +  1.0f, this.transform.position.z), Quaternion.identity);
                    break;
                case 4:
                    break;
            }
        }
    }
}
