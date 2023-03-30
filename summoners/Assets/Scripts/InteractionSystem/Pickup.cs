using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject player;

    private bool isInteracted = false;
    private bool isPickedUp = false;

    private Vector3 playerPositionOffset;
    public float pickupSpeed = 3f;
    //dupa :)
    public bool Interact(Interactor interactor)
    {
        isInteracted = true;
        Debug.Log("Pickup");
        return true;
    }


    private void Update()
    {
        playerPositionOffset = player.transform.position + Vector3.forward * 2f;

        if (isInteracted)
        { 
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            transform.parent = player.transform;
            transform.localPosition = new Vector3(0, 0, 0) + transform.forward;

            isInteracted = false;
        }
    }
}

