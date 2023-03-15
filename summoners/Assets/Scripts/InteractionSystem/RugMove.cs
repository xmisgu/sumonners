using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugMove : MonoBehaviour, IInteractable
{

    //private bool moved = false;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    //private Transform target;


    private float speed = 5f;
    private bool isInteracted = false;
    private Vector3 targetPosition = new Vector3(1.04f, 0.11f, 3.64f);


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
            Debug.Log("check2");
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
        }
    }
}