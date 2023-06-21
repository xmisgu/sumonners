using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireplaceButton : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] AudioSource buttonSound;
    public string InteractionPrompt => _prompt;
    private Vector3 targetPosition = new Vector3(4.35f, 1.663f, 3.079f);
    private bool isInteracted = false;
    private float speed = 0.5f;
    private float rotationSpeed = 50f;
    private Vector3 finalRotation = new Vector3(0, 0, -100);
    [SerializeField] private GameObject ClockFace;

    public bool Interact(Interactor interactor)
    {
        isInteracted = true;
        Debug.Log("check");
        buttonSound.Play();
        return true;
    }


    private void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        var step2 = speed * Time.deltaTime * 60;
        if (isInteracted)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
           // ClockFace.transform.Rotate(new Vector3(0, 0, -100) * Time.deltaTime);
            if (ClockFace.transform.rotation.z < 0.65)
                Debug.Log(ClockFace.transform.rotation.z);
                ClockFace.transform.Rotate(new Vector3(0, 0, -(rotationSpeed * Time.deltaTime)));
            // if (ClockFace.transform.eulerAngles.z > finalRotation.z)
            //     ClockFace.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
            // ClockFace.Rotate
        }


    }

}