using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField]
    private CuttingSCO[] cuttingRecipeSCOArray;

    private int cuttingCount;
    public override void interact(PlayerMovement player)
    {
        if(!HasFoodObject())
        {
            if (player.HasFoodObject())
            {
                if (HasRecipeInput(player.GetFoodIteam().GetFoodSco()))
                {
                    player.GetFoodIteam().SetFoodParent(this);
                    cuttingCount = 0;
                }
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

        if(HasFoodObject() && HasRecipeInput(GetFoodIteam().GetFoodSco()))
        {
            cuttingCount++;
            CuttingSCO cuttingSco = GetCuttingSCOwithInput(GetFoodIteam().GetFoodSco());
            if (cuttingCount > cuttingSco.cutMaxim)
            {
                FoodSCO OutputFood = GetOutputForInput(GetFoodIteam().GetFoodSco());
                GetFoodIteam().DestroyMeself();
                Food.SpawnFoodItem(OutputFood, this);
            }
        }
    }

    private bool HasRecipeInput(FoodSCO inputFoodSCO)
    {
        CuttingSCO cuttingSco = GetCuttingSCOwithInput(inputFoodSCO);
        return cuttingSco != null;
    }
    private FoodSCO GetOutputForInput(FoodSCO inputFood)
    {
        CuttingSCO cuttingSco = GetCuttingSCOwithInput(inputFood);
        if (cuttingSco != null)
            return cuttingSco.output;
        else
            return null;
    }

    private CuttingSCO GetCuttingSCOwithInput(FoodSCO inputfoodsco)
    {
        foreach (CuttingSCO cuttingSCO in cuttingRecipeSCOArray)
        {
            if (cuttingSCO.input == inputfoodsco)
                return cuttingSCO;
        }
        return null;
    }
}
