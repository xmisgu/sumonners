using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierPull : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public GameObject arm;
    public GameObject shelf;
    public string InteractionPrompt => _prompt;
    private float rotationSpeed = 50f;
    private float speed = 5f;
    private bool isInteracted = false;
    private Vector3 finalRotation = new Vector3(0, 0, 45);
    private Vector3 targetPosition = new Vector3(17.218873977661134f, 1.388190507888794f, -316.87200927734377f);

    public bool Interact(Interactor interactor)
    {

        isInteracted = true;
        Debug.Log("Level completed");
        return true;
    }

    private void Update()
    {
        if (isInteracted)
        {
            if (arm.transform.eulerAngles.z < finalRotation.z)
                arm.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
            else if(shelf.transform.position.z < -316.87200927734377f)
            {
                shelf.transform.position = Vector3.MoveTowards(shelf.transform.position, targetPosition, speed * Time.deltaTime);
            }

        }
    }
}
