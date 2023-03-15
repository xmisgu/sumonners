using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;
    [SerializeField] private Camera _camera;


    private IInteractable _interactable;
    private void Update()
    {
        Vector3 _rayDirection = _interactionPoint.transform.position - _camera.transform.position;
        RaycastHit hit;
        float distance = Vector3.Distance(_camera.transform.position, _interactionPoint.transform.position);
        bool isHit = Physics.Raycast(_camera.transform.position, _rayDirection, out hit, distance, _interactableMask);
        //Check for interaction item
        if(isHit)
        {
            _interactable = hit.collider.GetComponent<IInteractable>();
            if (_interactable != null)
            {
                if (!_interactionPromptUI.isDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
            }
            
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.isDisplayed) _interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; 
        Gizmos.DrawRay(_camera.transform.position, _interactionPoint.transform.position - _camera.transform.position);
    }
}
