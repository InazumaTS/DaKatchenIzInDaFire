using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, I_FoodParent
{
    [SerializeField]
    protected Transform counterTopPrefab;

    private Food food;

    public virtual void interact(PlayerMovement player)
    {

    }

    public virtual void interactAlt(PlayerMovement player)
    {

    }

    public Transform GetFoodItemFollowObject()
    {
        return counterTopPrefab;
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
