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

    public bool Interact(Interactor interactor)
    { 
        isInteracted = true;
        Debug.Log("Pickup");
        return true;
    }

    private void Update()
    {
        if (isInteracted)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            transform.parent = player.transform;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().enabled = false;
            isInteracted = false;
        }
    }
}
