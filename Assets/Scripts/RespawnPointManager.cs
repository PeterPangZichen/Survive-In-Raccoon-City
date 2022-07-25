using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPointManager : MonoBehaviour
{
    public GameObject ZombiePrefeb;
    public MenuData MenuData;
    
    private int numOfZombies;
    private float timer;
    private float delayTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        numOfZombies = MenuData.NumOfZombies;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= delayTime&&numOfZombies>0){
            numOfZombies--;
            timer = 0;
            Instantiate(ZombiePrefeb, new Vector3(this.transform.position.x, this.transform.position.y  +  1.0f, this.transform.position.z), Quaternion.identity);
        }
    }
}
