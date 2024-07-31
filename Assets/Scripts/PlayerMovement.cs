using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Update is called once per frame
    
    [SerializeField]
    private float MoveSpeed = 7f;
    private bool IsWalking = false;
    [SerializeField]
    private PlayerInput input;
    private void Update()
    {
        Vector2 PlayerMove = input.GetMovementVectorNormalized();
        Vector3 ProperPlayerMove = new Vector3(PlayerMove.x,0,PlayerMove.y);
        IsWalking = ProperPlayerMove != Vector3.zero;
        transform.position += ProperPlayerMove * Time.deltaTime * MoveSpeed;
        float RotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, ProperPlayerMove, Time.deltaTime * RotationSpeed);
    }

    public bool isWalking()
    {
        return IsWalking;
    }
}
