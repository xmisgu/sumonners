using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OpenSafe : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_InputField[] codeInput;
    [SerializeField] private string prompt;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMoveAndRotation playerMoveAndRotation;
    [SerializeField] private Camera camera;
    [SerializeField] private string[] code;
    [SerializeField] private float speed;


    private Vector3 newDirection;
    private bool isInteracted;
    private bool isRotated = false;
    private Vector3 target = new Vector3(34.5f, 2f, 0f);
    public string InteractionPrompt => prompt;
    
    private void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void LockPlayerMovement()
    {
        playerController.enabled = false;
        playerMoveAndRotation.enabled = false;
    }
    public void RotateCamera()
    {
        var step = speed * Time.deltaTime;
        camera.fieldOfView = Mathf.MoveTowards(camera.fieldOfView, 59, speed * Time.deltaTime * 20);

        if (camera.transform.eulerAngles.x < target.x)
            camera.transform.Rotate(new Vector3(target.x * step, 0, 0));
        if (camera.transform.eulerAngles.y < target.y)
            camera.transform.Rotate(new Vector3(0, target.y * step, 0));

        if(camera.transform.eulerAngles.x >= target.x && camera.transform.eulerAngles.y >= target.y && camera.fieldOfView == 59)
            isRotated = true;


    }
    private bool CheckCode(string[] code)
    {
        if(this.code == code)
            return true;
        return false;
    }
    public bool Interact(Interactor interactor)
    {
        UnlockCursor();
        LockPlayerMovement();
        playerController.gameObject.transform.position = new Vector3(19.5f, 1, -316);
        playerController.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        isInteracted = true;

        return true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isInteracted && !isRotated)
        {
            RotateCamera();
        }
        else if (isRotated)
        {
            canvas.SetActive(true);
        }
    }
}
