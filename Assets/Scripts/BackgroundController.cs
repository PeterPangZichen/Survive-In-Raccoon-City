using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float ftime;
    private bool index;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray = new Sprite[2];
    public bool start = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start){
            ftime += Time.deltaTime;
            if(ftime >= 0.5f)
            {
                if(index){
                    spriteRenderer.sprite = spriteArray[0];
                }else{
                    spriteRenderer.sprite = spriteArray[1];
                }
                index = !index;
                ftime = 0f;
            }
        }
    }
}
