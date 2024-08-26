using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbed;

    [SerializeField]
    private FoodSCO foodItem;
    public override void interact(PlayerMovement player)
    {
        if (!player.HasFoodObject())
        {
            Food.SpawnFoodItem(foodItem,player);
            OnPlayerGrabbed?.Invoke(this, EventArgs.Empty);
        }
    }
    
}
