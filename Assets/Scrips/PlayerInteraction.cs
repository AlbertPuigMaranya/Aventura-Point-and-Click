using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems; 

public class PlayerInteraction : MonoBehaviour
{
    private InputAction clickAction;
    public Camera mainCamera; // Arrastra tu cámara principal aquí

    private void Awake()
    {
        clickAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
        clickAction.performed += ctx => OnClick(); // Llama a OnClick cuando se presiona
        clickAction.Enable();

        if (mainCamera == null)
        {
            mainCamera = Camera.main; 
        }
    }

    private void OnDestroy()
    {
        clickAction?.Disable();
        clickAction?.Dispose();
    }

    private void OnClick()
    {
   
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Vector2 worldPos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
        }
    }
}