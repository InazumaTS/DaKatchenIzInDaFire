using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInputAction PInputAction;
    private void Awake()
    {
        PInputAction = new PlayerInputAction();
        PInputAction.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 PlayerMove = PInputAction.Player.Run.ReadValue<Vector2>();


        
        PlayerMove = PlayerMove.normalized;
        return PlayerMove;
    }
}
