using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvlItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    private bool isInteracted = false;
    public GameObject player;
    // private transform teleportTarget;
    private Vector3 targetPosition = new Vector3(-0.43f, 1.2f, 0.0052f);
    private Vector3 targetPosition2 = new Vector3(-23.185f,5.23f,19.99f);

    // void Start()
    // {
    //     teleportTarget = (-0.43f, 1.1f, 0.0052f);
    // }


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
            //x -0.43 y 1.1 z 0.0052
           // player.transform.position = targetPosition.transform.position; 
           player.transform.position = targetPosition;
           transform.localPosition = targetPosition2;

           //player.transform.position = teleportTarget.transform.position;
        }


    }

}
