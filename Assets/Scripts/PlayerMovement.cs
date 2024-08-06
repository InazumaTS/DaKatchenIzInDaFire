using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, I_FoodParent
{
    public static PlayerMovement Instance
    {
        get; private set;
    }

    public event EventHandler<OnSelectedCounterEventArgs> onSelectedCounterChanged;
    public class OnSelectedCounterEventArgs : EventArgs
    {
        public BaseCounter SelectedCounter;
    }

    // Update is called once per frame
    [SerializeField]
    private float MoveSpeed = 7f;
    [SerializeField]
    private PlayerInput input;
    [SerializeField]
    private float PlayerRadiusSize = 0.7f;
    [SerializeField]
    private float PlayerHeight = 2f;
    [SerializeField]
    private LayerMask countersLayerMask;
    [SerializeField]
    private Transform foodOnWhatPoint;

    private Food food;
    private bool IsWalking = false;
    private Vector3 LastInteractedDirection;
    private BaseCounter CounterSelected;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        input.OnInteractAction += Input_OnInteractAction;
    }

    private void Input_OnInteractAction(object sender, System.EventArgs e)
    {
        if (CounterSelected != null)
            CounterSelected.interact(this);

    }

    private void Update()
    {
        Vector2 PlayerMove = input.GetMovementVectorNormalized();
        Vector3 ProperPlayerMove = new Vector3(PlayerMove.x, 0, PlayerMove.y);
        IsWalking = ProperPlayerMove != Vector3.zero;

        collisionDetection(ProperPlayerMove);
        handleInteractions(ProperPlayerMove);
        float RotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, ProperPlayerMove, Time.deltaTime * RotationSpeed);
    }

    private void collisionDetection(Vector3 ProperPlayerMove)
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

    private void handleInteractions(Vector3 ProperPlayerMove)
    {
        Vector2 Move2D = input.GetMovementVectorNormalized();
        Vector3 Move = new Vector3(Move2D.x, 0, Move2D.y);
        float InteractDistance = 2f;
        if (Move != Vector3.zero)
            LastInteractedDirection = Move;
        if (Physics.Raycast(transform.position, LastInteractedDirection, out RaycastHit RayCastHit, InteractDistance, countersLayerMask))
        {
            if (RayCastHit.transform.TryGetComponent(out BaseCounter ClearCo))
            {
                if (ClearCo!=CounterSelected)
                {
                    setSelectedCounter(ClearCo);
                    
                }
            }
            else
            { 
                setSelectedCounter(null);
            }
        }
        else
        {

            setSelectedCounter(null);
        }
    }
    public bool isWalking()
    {
        return IsWalking;
    }
    private void setSelectedCounter(BaseCounter selectedCounter)
    {
        this.CounterSelected = selectedCounter;
        onSelectedCounterChanged?.Invoke(this, new OnSelectedCounterEventArgs
        {
            
            SelectedCounter = selectedCounter
        });
        
    }

    public Transform GetFoodItemFollowObject()
    {
        return foodOnWhatPoint;
    }

    public void SetFoodItem(Food foodMem)
    {
        this.food = foodMem;
    }

    public Food GetFoodIteam()
    {

        return food;
    }

    public void ClearFoodItem()
    {
        food = null;
    }

    public bool HasFoodObject()
    {
        return food != null;
    }
}

