using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : Food
{
    [SerializeField]
    private List<FoodSCO> validIngredients;
    private List<FoodSCO> FoodSCOList;

    private void Awake()
    {
        FoodSCOList = new List<FoodSCO>();
    }
    public bool TryAddIngredient(FoodSCO foodSCO)
    {
        if (!validIngredients.Contains(foodSCO))
        {
            return false;
        }
        if (!FoodSCOList.Contains(foodSCO))
        {
            FoodSCOList.Add(foodSCO);
            return true;
        }
        else
            return false;
    }
}
