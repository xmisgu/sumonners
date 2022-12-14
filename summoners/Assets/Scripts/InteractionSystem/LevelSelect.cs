using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] private float level;

    public bool Interact(Interactor interactor)
    {
        switch (level)
        {
            case 1: Debug.Log("LEVEL1");
                break;
            case 2:
                Debug.Log("LEVEL2");
                break;
            case 3:
                Debug.Log("LEVEL3");
                break;
        }
        return true;
    }
}
