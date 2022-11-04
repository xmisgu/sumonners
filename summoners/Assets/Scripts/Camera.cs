using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //basic camera follow of players position and rotation
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }
}
