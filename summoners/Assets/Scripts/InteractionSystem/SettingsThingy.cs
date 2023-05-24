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
            player.transform.position = new Vector3(-10.5f, 3, 0.5f);
            player.transform.eulerAngles = new Vector3(0, 80, 0);
            ZoomCamera(40);
            RotateCamera(new Vector3(0, 0, 0));
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
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, target, 30 * Time.deltaTime);
    }
    void RotateCamera(Vector3 target)
    {
        var step = 10 * Time.deltaTime;
        if (playerCamera.transform.eulerAngles.x < target.x)
            playerCamera.transform.Rotate(new Vector3(target.x * step, 0, 0));
        if (playerCamera.transform.eulerAngles.y < target.y)
            playerCamera.transform.Rotate(new Vector3(0, target.y * step, 0));
    }
}
