using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierPull : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public GameObject arm;
    public string InteractionPrompt => _prompt;
    private float rotationSpeed = 50f;
    private bool isInteracted = false;
    private Vector3 finalRotation = new Vector3(0, 0, 45);
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

        }
    }
}
