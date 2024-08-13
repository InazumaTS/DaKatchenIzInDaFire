using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField]
    private FoodSCO cutFoodObjectSCO;
    public override void interact(PlayerMovement player)
    {
        if(!HasFoodObject())
        {
            if (player.HasFoodObject())
            {
                player.GetFoodIteam().SetFoodParent(this);
            }
            else
            {

            }
        }
        else
        {
            if (player.HasFoodObject())
            {

            }
            else
            {
                GetFoodIteam().SetFoodParent(player);
            }
        }
    }

    public override void interactAlt(PlayerMovement player)
    {
        if(HasFoodObject())
        {
            GetFoodIteam().DestroyMeself();
            GameObject FoodGameobject = Instantiate(cutFoodObjectSCO.prefab);
            FoodGameobject.GetComponent<Food>().SetFoodParent(this);
        }
    }
}
