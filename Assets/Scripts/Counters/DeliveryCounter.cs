using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void interact(PlayerMovement player)
    {
        if(player.HasFoodObject())
        {
            if (player.GetFoodIteam().TryGetPlate(out PlateKitchenObject plate))
            {
                player.GetFoodIteam().DestroyMeself();
            }
        }
    }

}
