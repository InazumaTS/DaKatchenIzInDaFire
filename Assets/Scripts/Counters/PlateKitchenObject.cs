using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : Food
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientsAdded;

    public class OnIngredientAddedEventArgs : EventArgs
    {
        public FoodSCO foodSCO;
    }

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
            OnIngredientsAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                foodSCO = foodSCO
            });
            return true;
        }
        else
            return false;
    }

    public List<FoodSCO> GetKitchenObjectSO()
    {
        return FoodSCOList; 
    }
}
