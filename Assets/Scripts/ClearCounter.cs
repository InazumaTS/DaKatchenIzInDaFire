using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField]
    private FoodSCO foodItem;

    public override void interact(PlayerMovement player)
    {
        if(!HasFoodObject())
        {
            if(player.HasFoodObject())
            {
                player.GetFoodIteam().SetFoodParent(this);
            }
            else
            {

            }
        }
        else
        {
            if(player.HasFoodObject() )
            {

            }
            else
            {
                GetFoodIteam().SetFoodParent(player);
            }
        }
    }

    

}
