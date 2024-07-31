using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInputAction PInputAction;
    public event EventHandler OnInteractAction;
    private void Awake()
    {
        PInputAction = new PlayerInputAction();
        PInputAction.Player.Enable();
        PInputAction.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 PlayerMove = PInputAction.Player.Run.ReadValue<Vector2>();


        
        PlayerMove = PlayerMove.normalized;
        return PlayerMove;
    }

    
}
