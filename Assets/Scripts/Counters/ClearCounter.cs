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
                if(player.GetFoodIteam().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if(plateKitchenObject.TryAddIngredient(GetFoodIteam().GetFoodSco()))
                    GetFoodIteam().DestroyMeself();
                }
                else if(GetFoodIteam().TryGetPlate(out PlateKitchenObject plateKitchenObject1))
                {
                    if (plateKitchenObject1.TryAddIngredient(player.GetFoodIteam().GetFoodSco()))
                        player.GetFoodIteam().DestroyMeself();
                }
            }
            else
            {
                GetFoodIteam().SetFoodParent(player);
            }
        }
    }

    

}
