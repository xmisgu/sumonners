using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class LevelSelect : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] private int level;
    [SerializeField] Teleporting teleport;

    public bool Interact(Interactor interactor)
    {
        teleport.selectedLvl = level;
        Debug.Log("Level selected");
        return true;
    }
}
