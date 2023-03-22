using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    private float pickupSpeed = 5f;
    private bool isInteracted = false;
    public GameObject player;

    public bool Interact(Interactor interactor)
    {

        isInteracted = true;
        Debug.Log("Pickup");
        return true;
    }

    private void Update()
    {
        Vector3 playerPositionOffset = player.transform.position;
        if (isInteracted)
        {
            GetComponent<Collider>().enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, playerPositionOffset, pickupSpeed * Time.deltaTime);
        }
    }
}
