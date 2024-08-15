using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private FoodSCO foodSCO;
    private I_FoodParent foodObjectParent;
    public FoodSCO GetFoodSco()
    {

    return foodSCO; 
    }

    public void SetFoodParent(I_FoodParent foodParent)
    {

        if (this.foodObjectParent != null)
        {
            this.foodObjectParent.ClearFoodItem();
        }
        this.foodObjectParent = foodParent;
        foodParent.SetFoodItem(this);

        transform.parent = foodParent.GetFoodItemFollowObject();
        transform.localPosition = Vector3.zero;
    }

    public I_FoodParent GetFoodParent()
    {
        return foodObjectParent;
    }

    public void DestroyMeself()
    {
        foodObjectParent.ClearFoodItem();
        Destroy(gameObject);
    }

    public static Food SpawnFoodItem(FoodSCO foodSCO, I_FoodParent i_FoodParent)
    {
        GameObject FoodGameobject = Instantiate(foodSCO.prefab);
        Food food = FoodGameobject.GetComponent<Food>();
        
        food.SetFoodParent(i_FoodParent);
        return food;
    }
}
