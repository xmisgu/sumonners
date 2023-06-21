using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvlItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    private bool isInteracted = false;
    public GameObject player;
    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;
    // private transform teleportTarget;
    private Vector3 targetPosition = new Vector3(0.0f, 2.0f, 0.0052f);
    private Vector3 targetPosition2 = new Vector3(-16.19f,8.92f,-3.01f);
//UnityEditor.TransformWorldPlacementJSON:{"position":{"x":-16.197288513183595,"y":8.927164077758789,"z":-3.0149364471435549},"rotation":{"x":0.0,"y":0.0,"z":0.0,"w":1.0},"scale":{"x":1.0,"y":1.0,"z":1.0}}
   
   //Vector3(-16.1972885,8.92716408,-3.01493645)
   
    void Start()
    {
        Debug.Log("chuj");
    }


    public bool Interact(Interactor interactor)
    {
        isInteracted = true;
        Debug.Log("check");
        //buttonSound.Play();
        return true;
    }
    private void Update()
    {
        if (isInteracted)
        {
            Debug.Log("check");
            //x -0.43 y 1.1 z 0.0052
           // player.transform.position = targetPosition.transform.position; 
           player.transform.position = targetPosition;
           item1.SetActive(false);
           item2.SetActive(true);
           //transform.localPosition = targetPosition2;

           //player.transform.position = teleportTarget.transform.position;
        }


    }

}
