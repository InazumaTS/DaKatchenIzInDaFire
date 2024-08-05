using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private FoodSCO foodSCO;

    public FoodSCO GetFoodSco()
    {

    return foodSCO; 
    }
}
