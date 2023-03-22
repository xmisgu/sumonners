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
    public Rigidbody body;
    bool isPickedUp = false;
    public bool Interact(Interactor interactor)
    {

        isInteracted = true;
        Debug.Log("Pickup");
        return true;
    }
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotation;
    }
    private void Update()
    {
        Vector3 playerPositionOffset = player.transform.position + player.transform.forward / 5f;
        if (isInteracted)
        {
            transform.SetPositionAndRotation(Vector3.MoveTowards(transform.position, playerPositionOffset, pickupSpeed * Time.deltaTime), new Quaternion(0, 0, 0, 0));
            if (transform.position == playerPositionOffset)
            {
                isInteracted = false;
                isPickedUp = true;
            }
        }
        if (isPickedUp)
        {
            if (Physics.BoxCast(playerPositionOffset, new Vector3(0.01f, 0.01f, 0.01f), Vector3.forward / 10f))
                transform.SetPositionAndRotation(playerPositionOffset, new Quaternion(0, 0, 0, 0));
            else
            {
                body.constraints = RigidbodyConstraints.FreezePosition;
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }

        }
    }
}
