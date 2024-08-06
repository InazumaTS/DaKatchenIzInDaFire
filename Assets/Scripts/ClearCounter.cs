using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, I_FoodParent
{
    [SerializeField]
    private FoodSCO foodItem;
    [SerializeField]
    private Transform counterTopPrefab;

    private Food food;
    public void interact(PlayerMovement player)
    {
        if (food == null)
        {
            GameObject FoodGameobject = Instantiate(foodItem.prefab, counterTopPrefab);
            FoodGameobject.transform.localPosition = Vector3.zero;
            FoodGameobject.GetComponent<Food>().SetFoodParent(this);
        }
        else
        {
            food.SetFoodParent(player);
            
        }
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

    return food; }

    public void ClearFoodItem()
    {
        food = null;
    }

    public bool HasFoodObject()
    {
        return food != null; 
    }

}
