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
    [SerializeField]
    private float PlayerRadiusSize = 0.7f;
    [SerializeField]
    private float PlayerHeight = 2f;
    private void Update()
    {
        Vector2 PlayerMove = input.GetMovementVectorNormalized();
        Vector3 ProperPlayerMove = new Vector3(PlayerMove.x,0,PlayerMove.y);
        IsWalking = ProperPlayerMove != Vector3.zero;

        CollisionDetection(ProperPlayerMove);

        float RotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, ProperPlayerMove, Time.deltaTime * RotationSpeed);
    }

    private void CollisionDetection(Vector3 ProperPlayerMove)
    {
        bool canMove = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PlayerHeight, PlayerRadiusSize, ProperPlayerMove, Time.deltaTime * MoveSpeed);
        if (canMove)
        {
            Vector3 ProperPlayerMoveX = new Vector3(ProperPlayerMove.x, 0, 0);
            canMove = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PlayerHeight, PlayerRadiusSize, ProperPlayerMoveX, Time.deltaTime * MoveSpeed);
            if (!canMove)
                ProperPlayerMove = ProperPlayerMoveX;
            else
            {
                ProperPlayerMoveX = new Vector3(0, 0, ProperPlayerMove.z);
                canMove = Physics.CapsuleCast(transform.position, transform.position + Vector3.up * PlayerHeight, PlayerRadiusSize, ProperPlayerMoveX, Time.deltaTime * MoveSpeed);
                if (!canMove)
                    ProperPlayerMove = ProperPlayerMoveX;

            }

        }
        if (!canMove)
            transform.position += ProperPlayerMove * Time.deltaTime * MoveSpeed;
    }

    public bool isWalking()
    {
        return IsWalking;
    }
}
