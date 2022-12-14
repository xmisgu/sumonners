using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public GameObject player;

    [SerializeField] GameObject tp1;
    [SerializeField] GameObject tp2;
    [SerializeField] GameObject tp3;


    void OnTriggerEnter()
    {
        player.transform.position = tp1.transform.position;
    }
}
