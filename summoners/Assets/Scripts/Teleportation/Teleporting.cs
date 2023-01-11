using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject teleporter;
    [SerializeField] GameObject tp1;
    [SerializeField] GameObject tp2;
    [SerializeField] GameObject tp3;
    
    public int selectedLvl = 0;

    private void Update()
    {
        if (this.selectedLvl != 0)
        {
            teleporter.SetActive(true);
        }
        else
        {
            teleporter.SetActive(false);
        }
        
    }

    void OnTriggerEnter()
    {
        switch (selectedLvl)
        {      
            case 1:
                player.transform.position = tp1.transform.position; 
                break;
            case 2:
                player.transform.position = tp2.transform.position;
                break;
           case 3:
                player.transform.position = tp3.transform.position;
                break;
        }
        selectedLvl = 0;
        Debug.Log("WEJSZEDNIETE ZOSTALO");
    }

    
}
