using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvlItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    private bool isInteracted = false;
    public GameObject player;
    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;
    private Vector3 targetPosition = new Vector3(0.0f, 2.0f, 0.0052f);
    private Vector3 targetPosition2 = new Vector3(-16.19f,8.92f,-3.01f);

    public bool Interact(Interactor interactor)
    {
        isInteracted = true;
        Debug.Log("check");
        //buttonSound.Play();
        return true;
    }
    private void Update()
    {
        if (isInteracted)
        {
            Debug.Log("check");
           player.transform.position = targetPosition;
           item1.SetActive(false);
           item2.SetActive(true);
        }


    }

}
