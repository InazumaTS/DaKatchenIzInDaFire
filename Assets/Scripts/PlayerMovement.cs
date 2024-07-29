using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Update is called once per frame
    
    [SerializeField]
    private float MoveSpeed = 7f;
    private bool IsWalking = false;
    private void Update()
    {
        Vector2 PlayerMove = new Vector2(0,0);

        if(Input.GetKey(KeyCode.W))
        {
            PlayerMove.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerMove.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerMove.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerMove.x = -1;
        }
        PlayerMove = PlayerMove.normalized;
        
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
