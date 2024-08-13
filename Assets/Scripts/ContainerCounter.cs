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
            GameObject FoodGameobject = Instantiate(foodItem.prefab, counterTopPrefab);
            FoodGameobject.transform.localPosition = Vector3.zero;
            FoodGameobject.GetComponent<Food>().SetFoodParent(player);
            OnPlayerGrabbed?.Invoke(this, EventArgs.Empty);
        }
    }
    
}
