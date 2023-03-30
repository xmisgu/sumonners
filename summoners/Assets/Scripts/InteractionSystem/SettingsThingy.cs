using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class SettingsThingy : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    private bool isInteracted = false;
    public float defaultFov = 90;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCamera;

    public bool Interact(Interactor interactor)
    {
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<PlayerController>().enabled = false;
        playerCamera.GetComponent<PlayerMoveAndRotation>().enabled= false;
        isInteracted = true;
        return true;
    }

    void Start()
    {
        playerCamera.fieldOfView = defaultFov;
    }

    private void Update()
    {
        if (isInteracted) {
            ZoomCamera(30);
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                player.GetComponent<PlayerController>().enabled = true;
                playerCamera.GetComponent<PlayerMoveAndRotation>().enabled = true;
                playerCamera.fieldOfView = defaultFov;
                isInteracted = false;
            }
        }
    }

    void ZoomCamera(float target)
    {
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, target, 100 * Time.deltaTime);
    }
}
