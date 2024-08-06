using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_FoodParent 
{
    public Transform GetFoodItemFollowObject();

    public void SetFoodItem(Food foodMem);

    public Food GetFoodIteam();

    public void ClearFoodItem();

    public bool HasFoodObject();
}
