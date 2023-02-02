using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandelierPull : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public GameObject arm;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        arm.transform.eulerAngles = new Vector3(0, 0, 45);
        Debug.Log("Level completed");
        return true;
    }
}
