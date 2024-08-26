using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct FoodSCOGameObject
    {
        public FoodSCO foodSCO;
        public GameObject gameObject;
    }

    [SerializeField]
    private PlateKitchenObject kitchenObject;
    [SerializeField]
    private List<FoodSCOGameObject> foodSCOGameObjList;

    private void Start()
    {
        kitchenObject.OnIngredientsAdded += KitchenObject_OnIngredientsAdded;
        foreach (FoodSCOGameObject foodSCOGameObject in foodSCOGameObjList)
        {
                foodSCOGameObject.gameObject.SetActive(false);
        }
    }

    private void KitchenObject_OnIngredientsAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (FoodSCOGameObject foodSCOGameObject in foodSCOGameObjList)
        {
            if(foodSCOGameObject.foodSCO == e.foodSCO)
            {
                foodSCOGameObject.gameObject.SetActive(true);
            }
        }
    }
}
