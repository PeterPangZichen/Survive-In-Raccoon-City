using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -5.3f, 6.36f), Mathf.Clamp(player.transform.position.y, -9f, 0.14f), player.transform.position.z - 10);
        // x range -5.3f 6.36f
        // y range -9f 0.14f
    }
}
