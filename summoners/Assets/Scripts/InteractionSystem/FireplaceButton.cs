using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceButton : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    private Vector3 targetPosition = new Vector3(4.35f, 1.663f, 3.079f);
    private bool isInteracted = false;
    private float speed = 0.5f;

    public bool Interact(Interactor interactor)
    {
        isInteracted = true;
        Debug.Log("check");
        return true;
    }


    private void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        if (isInteracted)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
        }


    }

}